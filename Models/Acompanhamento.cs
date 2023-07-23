using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralizadorExames.Models
{
    public class Acompanhamento
    {
        public int Id { get; set; }
        public Paciente? Paciente { get; set; }
        public IEnumerable<Profissional>? Profissionais { get; set; }
        public IEnumerable<Exame>? Exames { get; set; }
        public bool Status { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataFechamento { get; set; }
    }
}