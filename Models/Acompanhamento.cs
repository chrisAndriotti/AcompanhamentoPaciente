using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcompanhamentoPaciente.Models
{
    public class Acompanhamento
    {
        public int Id { get; set; }
        public Paciente? Paciente { get; set; }
        public IEnumerable<Profissional>? Profissionais { get; set; }
        public IEnumerable<Exame>? Exames { get; set; }
        public bool Status { get; set; } = false;
        public DateTime DataAbertura { get; set; }
        public DateTime DataFechamento { get; set; }

        public Acompanhamento() {  }
        public Acompanhamento(Paciente? paciente, IEnumerable<Profissional>? profissionais,
            IEnumerable<Exame>? exames, DateTime dataAbertura, DateTime dataFechamento)
        {
            this.Paciente = paciente;
            this.Profissionais = profissionais;
            this.Exames = exames;
            this.DataAbertura = dataAbertura;
            this.DataFechamento = dataFechamento;
        }
    }
}