using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcompanhamentoPaciente.DTOs
{
    public class AcompanhamentoDTO
    {
        public int IdPaciente { get; set; }
        public List<int> IdsProfissionais { get; set; }
        public List<int> IdsExames { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataFechamento { get; set; }
    }
}