namespace AcompanhamentoPaciente.Models
{
   public class Paciente
   {
      public int Id { get; set; }
      public string? Nome { get; set; }
      public int Idade { get; set; }
      public DateTime DataNascimento { get; set; }
      public string? Email { get; set; }
      public string? Telefone { get; set; }
      public string? NomeResponsavel { get; set; }
      public string? TelefoneReponsavel { get; set; }
   }
}