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
    public class ProfissionalController : ControllerBase
    {
        private readonly IProfissionalService _profissionalService;

        public ProfissionalController(IProfissionalService profissionalService)
        {
            _profissionalService = profissionalService;
        }
        
        [HttpGet("lista")]
        public async Task<IActionResult> Buscar()
        {
            var profissional = await _profissionalService.BuscarTodos();
            if (profissional is null)
                return NotFound();

            return Ok(profissional);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPaciente(int id)
        {
            var profissional = await _profissionalService.BuscarPorId(id);
            if (profissional is null)
                return NotFound();
            
            return Ok(profissional);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Profissional profissional)
        {
            var resultado = await _profissionalService.Adicionar(profissional);
            if (resultado is false)
                return NoContent();

            return Ok(resultado);
        }

        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Profissional profissional)
        {
            var resultado = await _profissionalService.Atualizar(id, profissional);
            if (resultado is false)
                return NoContent();

            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirPorId(int id)
        {
            var resultado = await _profissionalService.ExcluirPorId(id);
            if (resultado is false)
                return NoContent();

            return Ok(resultado);
        }
    }
}