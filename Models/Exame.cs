namespace AcompanhamentoPaciente.Models
{
   public class Exame
   {
      public int Id { get; set; }
      public string? Nome { get; set; }
      public string? Descricao { get; set; }
      public DateTime Data { get; set; } 
   }
}