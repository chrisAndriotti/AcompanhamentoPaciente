using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcompanhamentoPaciente.Models;

namespace AcompanhamentoPaciente.Services.Interfaces
{
    public interface IProfissionalService
    {
        public IEnumerable<Profissional> BuscarTodos();
        public Profissional? BuscarPorId(int id);
        public Task<bool> Adicionar(Profissional profissional);
        public Task<bool> Atualizar(int id, Profissional profissional);
        public Task<bool> ExcluirPorId(int id);
    }
}