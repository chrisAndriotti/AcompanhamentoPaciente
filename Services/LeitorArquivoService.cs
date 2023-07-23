using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralizadorExames.Services
{
    public class LeitorArquivoService : ILeitorArquivoService
    {
        private readonly IWebHostEnvironment _webHostEnviroment;

        public LeitorArquivoService(IWebHostEnvironment webHostEnviroment)
        {
            _webHostEnviroment = webHostEnviroment;
            
        }
        
        public async Task<bool> LerDados(List<IFormFile> arquivos)
        {
            if(arquivos is null)
                return false;
    
            // Pasta do servidor para salvar os docs do paciente
            string diretorio = Path.Combine(_webHostEnviroment.ContentRootPath, "ArquivosTeste");

            foreach(var arquivo in arquivos)
            {
                string arquivoDiretorio = Path.Combine(diretorio, arquivo.FileName);
                
                using (var stream = new FileStream(arquivoDiretorio, FileMode.Create))
                {
                    arquivo.CopyTo(stream);
                    stream.Close();
                }
            }

            return true;
        }
    }
}