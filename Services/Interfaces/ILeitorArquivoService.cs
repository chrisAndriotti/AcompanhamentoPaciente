using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralizadorExames.Services
{
    public interface ILeitorArquivoService
    {
        public Task<bool> LerDados(List<IFormFile> arquivos);
    }
}