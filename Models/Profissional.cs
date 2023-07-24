namespace AcompanhamentoPaciente.Models
{
   public class Profissional
   {
      public int Id { get; set; }
      public string? Nome { get; set; }
      public Cargo? Cargo { get; set; }
      public string? Registro { get; set; }
   }
}