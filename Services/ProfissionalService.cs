using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcompanhamentoPaciente.Data;
using AcompanhamentoPaciente.Models;
using AcompanhamentoPaciente.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AcompanhamentoPaciente.Services
{
    public class ProfissionalService : IProfissionalService
    {
        private readonly DataContext _context;
        
        public ProfissionalService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public IEnumerable<Profissional> BuscarTodos()
        {
            return _context.Profissional.Include(c => c.Cargo);
        }

        public Profissional? BuscarPorId(int id)
        {
            return _context.Profissional.Where(p => p.Id == id)
                                                    .Include(c => c.Cargo)
                                                    .FirstOrDefault();
        }

        public async Task<bool> Adicionar(Profissional profissional)
        {
            try
            {
                if (profissional.Cargo is null)
                    return false;

                var buscaCargo =  _context.Cargo.Where(x => x.Id == profissional.Cargo.Id).FirstOrDefault();

                if (buscaCargo is null)
                    return false;

                profissional.Cargo = buscaCargo;
                
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
                if (profissional.Cargo is null)
                    return false;

                var buscarProfissional = BuscarPorId(id);

                if (buscarProfissional is null)
                    return false;

                var buscaCargo = _context.Cargo.Where(c => c.Id == profissional.Cargo.Id).FirstOrDefault();

                if (buscaCargo is null)
                    return false;
                
                buscarProfissional.Nome = profissional.Nome;
                buscarProfissional.Registro = profissional.Registro;
                buscarProfissional.Cargo = buscaCargo;

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
                var buscarProfissional = BuscarPorId(id);
                
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