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
    public class ProfissionalService : IProfissionalService
    {
        private readonly DataContext _context;
        
        public ProfissionalService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<IEnumerable<Profissional>> BuscarTodos()
        {
            return await _context.Profissional.ToListAsync();
        }

        public async Task<Profissional?> BuscarPorId(int id)
        {
            return await _context.Profissional.FindAsync(id);
        }

        public async Task<bool> Adicionar(Profissional profissional)
        {
            try
            {
                _context.Profissional.Add(profissional);
                await _context.SaveChangesAsync();
                
                return true;
            }
            catch(Exception ex)
            {
                System.Console.WriteLine($"  >>>>> {ex.InnerException}");
                return false;
            }
        }

        public async Task<bool> Atualizar(int id, Profissional profissional)
        {
            try
            {
                var buscarProfissional = await BuscarPorId(id);

                if (buscarProfissional is null)
                    return false;
                
                buscarProfissional.Nome = profissional.Nome;
                buscarProfissional.Registro = profissional.Registro;
                buscarProfissional.Cargo = profissional.Cargo;

                await _context.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                System.Console.WriteLine($"  >>>>>>  {ex.InnerException}");
                return false;
            }
        }

        public async Task<bool> ExcluirPorId(int id)
        {
            try
            {
                var buscarProfissional = await BuscarPorId(id);
                
                if (buscarProfissional is null)
                    return false;
                
                _context.Profissional.Remove(buscarProfissional);
                await _context.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                System.Console.WriteLine($"  >>>>>>  {ex.InnerException}");
                return false;
            }
        }
    }
}