using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentralizadorExames.Models;

namespace CentralizadorExames.Services.Interfaces
{
    public interface IPacienteService
    {
        public Task<IEnumerable<Paciente>> BuscarTodos();
        public Task<Paciente> BuscarPorId(int id);
        public Task<bool> Adicionar(Paciente paciente);
        public Task<bool> Atualizar(int id, Paciente paciente);
        public Task<bool> ExcluirPorId(int Id);
    }
}