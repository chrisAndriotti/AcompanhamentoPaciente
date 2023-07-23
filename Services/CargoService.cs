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
    public class CargoService : ICargoService
    {
        private readonly DataContext _context;
        
        public CargoService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<IEnumerable<Cargo>> BuscarTodos()
        {
            return await _context.Cargo.ToListAsync();
        }

        public async Task<Cargo?> BuscarPorId(int id)
        {
            return await _context.Cargo.FindAsync(id);
        }

        public async Task<bool> Adicionar(Cargo cargo)
        {
            try
            {
                _context.Cargo.Add(cargo);
                await _context.SaveChangesAsync();
                
                return true;
            }
            catch(Exception ex)
            {
                System.Console.WriteLine($"  >>>>> {ex.InnerException}");
                return false;
            }
        }

        public async Task<bool> Atualizar(int id, Cargo cargo)
        {
            try
            {
                var buscarCargo = await BuscarPorId(id);

                if (buscarCargo is null)
                    return false;
                
                buscarCargo.Nome = cargo.Nome;

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
                var buscaCargo = await BuscarPorId(id);
                
                if (buscaCargo is null)
                    return false;
                
                _context.Cargo.Remove(buscaCargo);
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