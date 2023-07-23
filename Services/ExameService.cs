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
    public class ExameService : IExameService
    {
        private readonly DataContext _context;
        
        public ExameService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<IEnumerable<Exame>> BuscarTodos()
        {
            return await _context.Exame.ToListAsync();
        }

        public async Task<Exame?> BuscarPorId(int id)
        {
            return await _context.Exame.FindAsync(id);
        }

        public async Task<bool> Adicionar(Exame exame)
        {
            try
            {
                _context.Exame.Add(exame);
                await _context.SaveChangesAsync();
                
                return true;
            }
            catch(Exception ex)
            {
                System.Console.WriteLine($"  >>>>> {ex.InnerException}");
                return false;
            }
        }

        public async Task<bool> Atualizar(int id, Exame exame)
        {
            try
            {
                var buscarExame = await BuscarPorId(id);

                if (buscarExame is null)
                    return false;
                
                buscarExame.Nome = exame.Nome;
                buscarExame.Descricao = exame.Descricao;
                buscarExame.Data = exame.Data;

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
                var buscaExame = await BuscarPorId(id);
                
                if (buscaExame is null)
                    return false;
                
                _context.Exame.Remove(buscaExame);
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