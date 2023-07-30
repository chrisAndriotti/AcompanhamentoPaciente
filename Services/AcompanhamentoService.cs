using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcompanhamentoPaciente.Data;
using AcompanhamentoPaciente.DTOs;
using AcompanhamentoPaciente.Models;
using AcompanhamentoPaciente.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AcompanhamentoPaciente.Services
{
    public class AcompanhamentoService : IAcompanhamentoService
    {
        private readonly DataContext _context;
        
        public AcompanhamentoService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public IEnumerable<Acompanhamento> BuscarTodos()
        {
            return _context.Acompanhamento.Include(a => a.Profissionais)
                                          .Include(a => a.Exames)
                                          .Include(a => a.Paciente);
        }

        public async Task<Acompanhamento?> BuscarPorId(int id)
        {
            return await _context.Acompanhamento.Where(a => a.Id == id)
                                          .Include(a => a.Profissionais)
                                          .Include(a => a.Exames)
                                          .Include(a => a.Paciente)
                                          .FirstOrDefaultAsync();
        }
        public IEnumerable<Acompanhamento> BuscarPorPaciente(int idPaciente)
        {
            var paciente = _context.Paciente.Where(x => x.Id == idPaciente).FirstOrDefault();

            if (paciente is null) 
            {
                // TODO: evitar busca de paciente que não existe
            }
            var acompanhamentos = _context.Acompanhamento.Where(a => a.Paciente.Id == idPaciente) 
                                                        .Include(a => a.Profissionais)
                                                        .Include(a => a.Exames)
                                                        .Include(a => a.Paciente);
            return acompanhamentos;
        }

        public IEnumerable<Acompanhamento?> BuscarPorProfissional(int idProfissional)
        {
            var profissional = _context.Profissional.Where(x => x.Id == idProfissional).FirstOrDefault();

            if (profissional is null) 
            {
                // TODO: evitar busca de paciente que não existe
            }
            var acompanhamentos = _context.Acompanhamento.Include(a => a.Profissionais.Where(x => x.Id == idProfissional))
                                                        .Include(a => a.Exames)
                                                        .Include(a => a.Paciente);
            return acompanhamentos;
        }

        public async Task<bool> AdicionarAcompanhamento(AcompanhamentoDTO acompanhamento)
        {
            try
            {
                if (acompanhamento.IdPaciente < 0)
                    return false;
                var paciente = _context.Paciente.Where(p => p.Id == acompanhamento.IdPaciente).FirstOrDefault();
                var exames = BuscarExamesParaAcompanhamento(acompanhamento);
                var profissionais = BuscarProfissionaisParaAcompanhamento(acompanhamento);
                var acompanhamentoParaInsert = new Acompanhamento(paciente, profissionais, exames, acompanhamento.DataAbertura, acompanhamento.DataFechamento);
                
                _context.Add(acompanhamentoParaInsert);
                await _context.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                System.Console.WriteLine($"  >>>>>  {ex.InnerException}");
                return false;
            }
        }
        public async Task<bool> AtualizarAcompanhamento(int id, Acompanhamento acompanhamento)
        {
            try
            {
                if(acompanhamento.Paciente is null)
                    return false;
        
                var buscarAcompanhamento = await BuscarPorId(id);
                var buscarPaciente = _context.Paciente.Where(p => p.Id == acompanhamento.Paciente.Id);

                if(buscarAcompanhamento is null || buscarPaciente is null)
                    return false;

                buscarAcompanhamento.Paciente = acompanhamento.Paciente;
                buscarAcompanhamento.Profissionais = acompanhamento.Profissionais;
                buscarAcompanhamento.Status = acompanhamento.Status;
                buscarAcompanhamento.DataAbertura = acompanhamento.DataAbertura;
                buscarAcompanhamento.DataFechamento = acompanhamento.DataFechamento;
                buscarAcompanhamento.Exames = acompanhamento.Exames;

                await _context.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                System.Console.WriteLine($"  >>>>>  {ex.InnerException}");
                return false;
            }
        }

        private IEnumerable<Exame> BuscarExamesParaAcompanhamento(AcompanhamentoDTO acompanhamento)
        {
            if(acompanhamento.IdsExames is null)
                return Enumerable.Empty<Exame>();

            List<Exame> examesParaAcompanhamento = new List<Exame>();
            foreach(var idExame in acompanhamento.IdsExames)
            {
                var buscaExame = _context.Exame.Where(e => e.Id == idExame).FirstOrDefault();
                if (buscaExame is null)
                    continue;

                examesParaAcompanhamento.Add(buscaExame);
            }

            return examesParaAcompanhamento;
        }

        private IEnumerable<Profissional> BuscarProfissionaisParaAcompanhamento(AcompanhamentoDTO acompanhamento)
        {
            if(acompanhamento.IdsProfissionais is null)
                return Enumerable.Empty<Profissional>();

            List<Profissional> profissionaisParaAcompanhamento = new List<Profissional>();
            foreach(var idProfissional in acompanhamento.IdsProfissionais)
            {
                var buscaProfissional = _context.Profissional.Where(e => e.Id == idProfissional).FirstOrDefault();
                if (buscaProfissional is null)
                    continue;

                profissionaisParaAcompanhamento.Add(buscaProfissional);
            }

            return profissionaisParaAcompanhamento;
        }
    }
}