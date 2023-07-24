using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcompanhamentoPaciente.Models;

namespace AcompanhamentoPaciente.Services.Interfaces
{
    public interface ICargoService
    {
        public Task<IEnumerable<Cargo>> BuscarTodos();
        public Task<Cargo?> BuscarPorId(int id);
        public Task<bool> Adicionar(Cargo cargo);
        public Task<bool> Atualizar(int id, Cargo cargo);
        public Task<bool> ExcluirPorId(int id);
    }
}