using CentralizadorExames.Models;

namespace CentralizadorExames.Services.Interfaces
{
   public interface IAcompanhamentoService
   {
      Task<IEnumerable<Acompanhamento>> BuscarTodos();
      Task<Acompanhamento?> BuscarPorId(int id);
      IEnumerable<Acompanhamento> BuscarPorPaciente(int idPaciente);
      IEnumerable<Acompanhamento?> BuscarPorProfissional(int idProfissional);
      Task<bool> AdicionarAcompanhamento(Acompanhamento acompanhamento);
      Task<bool> AtualizarAcompanhamento(int id, Acompanhamento acompanhamento);
   }
}