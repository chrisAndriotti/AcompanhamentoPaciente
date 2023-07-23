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

        public async Task<Paciente> Adicionar(Paciente paciente)
        {
            _context.Paciente.Add(paciente);
            await _context.SaveChangesAsync();

            return paciente;
        }
        
        public async Task<Paciente?> Atualizar(int id, Paciente paciente)
        {
            var buscaPaciente = await BuscarPorId(id);
            
            if (buscaPaciente is null)
                return null;

            buscaPaciente.Nome = paciente.Nome;
            buscaPaciente.Idade = paciente.Idade;
            buscaPaciente.Email = paciente.Email;
            buscaPaciente.Telefone = paciente.Telefone;
            buscaPaciente.DataNascimento = paciente.DataNascimento;
            buscaPaciente.NomeResponsavel = paciente.NomeResponsavel;
            buscaPaciente.TelefoneReponsavel = paciente.TelefoneReponsavel;

            await _context.SaveChangesAsync();

            return buscaPaciente;
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