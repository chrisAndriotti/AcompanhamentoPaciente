using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentralizadorExames.Data;
using CentralizadorExames.Models;
using CentralizadorExames.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CentralizadorExames.Services
{
    public class AcompanhamentoService : IAcompanhamentoService
    {
        private readonly DataContext _context;
        
        public AcompanhamentoService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<IEnumerable<Acompanhamento>> BuscarTodos()
        {
            return await _context.Acompanhamento.ToListAsync();
        }

        public async Task<Acompanhamento?> BuscarPorId(int id)
        {
            return await _context.Acompanhamento.FindAsync(id);
        }
        public IEnumerable<Acompanhamento> BuscarPorPaciente(int idPaciente)
        {
            return _context.Acompanhamento.Where(a => a.Paciente.Id == idPaciente);
        }

        public IEnumerable<Acompanhamento?> BuscarPorProfissional(int idProfissional)
        {
            var acompanhamentos = _context.Acompanhamento.Where(x => x.Profissionais.Any(x => x.Id == idProfissional));

            return acompanhamentos;
        }

        public async Task<bool> AdicionarAcompanhamento(Acompanhamento acompanhamento)
        {
            try
            {
                _context.Add(acompanhamento);
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
                var buscarAcompanhamento = await BuscarPorId(id);

                if(buscarAcompanhamento is null)
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
    }
}