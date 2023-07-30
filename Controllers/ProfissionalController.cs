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

        /// <summary>
        /// Lista de todos os profissionais cadastrados.
        /// </summary>
        /// <returns></returns>
        [HttpGet("lista")]
        public IActionResult Buscar()
        {
            var profissional = _profissionalService.BuscarTodos();
            if (profissional is null)
                return NotFound();

            return Ok(profissional);
        }
        /// <summary>
        /// Busca um profissional por Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPaciente(int id)
        {
            var profissional = _profissionalService.BuscarPorId(id);
            if (profissional is null)
                return NotFound();

            return Ok(profissional);
        }
        /// <summary>
        /// Adiciona um novo profissional.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Adicionar([FromBody] Profissional profissional)
        {
            var resultado = await _profissionalService.Adicionar(profissional);
            if (resultado is false)
                return BadRequest();

            return Ok(resultado);
        }
        
        /// <summary>
        /// Atualizar um profissional.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Profissional profissional)
        {
            var resultado = await _profissionalService.Atualizar(id, profissional);
            if (resultado is false)
                return BadRequest();

            return Ok(resultado);
        }

        /// <summary>
        /// Exclui um profissional.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirPorId(int id)
        {
            var resultado = await _profissionalService.ExcluirPorId(id);
            if (resultado is false)
                return BadRequest();

            return Ok(resultado);
        }
    }
}