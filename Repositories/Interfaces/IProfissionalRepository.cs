using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentralizadorExames.Models;

namespace CentralizadorExames.Repositories.Interfaces
{
    public interface IProfissionalRepository
    {
        public Task<IEnumerable<Profissional>> BuscarTodos();
        public Task<Profissional?> BuscarPorId(int id);
        public Task<bool> Adicionar(Profissional profissional);
        public Task<bool> Atualizar(int id, Profissional profissional);
        public Task<bool> ExcluirPorId(int id);
    }
}