using AcompanhamentoPaciente.DTOs;
using AcompanhamentoPaciente.Models;

namespace AcompanhamentoPaciente.Services.Interfaces
{
   public interface IAcompanhamentoService
   {
      IEnumerable<Acompanhamento> BuscarTodos();
      Task<Acompanhamento?> BuscarPorId(int id);
      IEnumerable<Acompanhamento> BuscarPorPaciente(int idPaciente);
      IEnumerable<Acompanhamento?> BuscarPorProfissional(int idProfissional);
      Task<bool> AdicionarAcompanhamento(AcompanhamentoDTO acompanhamento);
      Task<bool> AtualizarAcompanhamento(int id, Acompanhamento acompanhamento);
   }
}