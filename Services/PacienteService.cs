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
    public class PacienteService : IPacienteService
    {
        private readonly DataContext _context;
        public PacienteService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<IEnumerable<Paciente>> BuscarTodos()
        {
            return await _context.Paciente.ToListAsync();
        }

        public async Task<Paciente> BuscarPorId(int id)
        {
            return await _context.Paciente.FindAsync(id);
        }

        public async Task<bool> Adicionar(Paciente paciente)
        {
            try
            {
                _context.Paciente.Add(paciente);
                await _context.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                System.Console.WriteLine($"  >>>>>  {ex.InnerException}");
                return false;
            }
        }
        
        public async Task<bool> Atualizar(int id, Paciente paciente)
        {
            try
            {
                var buscaPaciente = await BuscarPorId(id);
                
                if (buscaPaciente is null)
                    return false;

                buscaPaciente.Nome = paciente.Nome;
                buscaPaciente.Idade = paciente.Idade;
                buscaPaciente.Email = paciente.Email;
                buscaPaciente.Telefone = paciente.Telefone;
                buscaPaciente.DataNascimento = paciente.DataNascimento;
                buscaPaciente.NomeResponsavel = paciente.NomeResponsavel;
                buscaPaciente.TelefoneReponsavel = paciente.TelefoneReponsavel;

                await _context.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                System.Console.WriteLine($"  >>>>>  {ex.InnerException}");
                return false;
            }
        }

        public async Task<bool> ExcluirPorId(int id)
        {
            var buscaPaciente = await _context.Paciente.FindAsync(id);
            
            if (buscaPaciente is null)
                return false;
            
            _context.Paciente.Remove(buscaPaciente);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}