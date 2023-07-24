using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcompanhamentoPaciente.Models;

namespace AcompanhamentoPaciente.Services.Interfaces
{
    public interface IExameService
    {
        public Task<IEnumerable<Exame>> BuscarTodos();
        public Task<Exame?> BuscarPorId(int id);
        public Task<bool> Adicionar(Exame exame);
        public Task<bool> Atualizar(int id, Exame exame);
        public Task<bool> ExcluirPorId(int id);
    }
}