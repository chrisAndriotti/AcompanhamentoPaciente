using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcompanhamentoPaciente.Models;
using AcompanhamentoPaciente.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AcompanhamentoPaciente.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExameController : ControllerBase
    {
        private readonly IExameService _exameService;

        public ExameController(IExameService exameService)
        {   
            _exameService = exameService;
        }

        [HttpGet("lista")]
        public async Task<IActionResult> Buscar()
        {
            var exame = await _exameService.BuscarTodos();
            if (exame is null)
                return NotFound();

            return Ok(exame);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPaciente(int id)
        {
            var exame = await _exameService.BuscarPorId(id);
            if (exame is null)
                return NotFound();
            
            return Ok(exame);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Exame exame)
        {
            var resultado = await _exameService.Adicionar(exame);
            if (resultado is false)
                return NoContent();

            return Ok(resultado);
        }

        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Exame exame)
        {
            var resultado = await _exameService.Atualizar(id, exame);
            if (resultado is false)
                return NoContent();

            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirPorId(int id)
        {
            var resultado = await _exameService.ExcluirPorId(id);
            if (resultado is false)
                return NoContent();

            return Ok(resultado);
        }
    }
}