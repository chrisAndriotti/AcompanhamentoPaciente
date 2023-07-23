using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CentralizadorExames.Services;

namespace CentralizadorExames.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArquivosController : ControllerBase
    {
        private readonly ILeitorArquivoService _leitorArquivoService;

        public ArquivosController(ILeitorArquivoService leitorArquivoService)
        {
            _leitorArquivoService = leitorArquivoService;
        }

        [HttpPost("leitor-arquivos")]
        public async Task Upload(List<IFormFile> arquivos)
        {
            try
            {
                var leitor = _leitorArquivoService.LerDados(arquivos);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}