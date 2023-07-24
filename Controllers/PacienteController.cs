using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentralizadorExames.Models;
using CentralizadorExames.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CentralizadorExames.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }
        
        [HttpGet("lista")]
        public async Task<IActionResult> Buscar()
        {
            var pacientes = await _pacienteService.BuscarTodos();
            if (pacientes is null)
                return NotFound();

            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPaciente(int id)
        {
            var paciente = await _pacienteService.BuscarPorId(id);
            if (paciente is null)
                return NotFound();
            
            return Ok(paciente);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Paciente paciente)
        {
            var resultado = await _pacienteService.Adicionar(paciente);
            if (resultado is false)
                return NoContent();

            return Ok(resultado);
        }

        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Paciente paciente)
        {
            var resultado = await _pacienteService.Atualizar(id, paciente);
            if (resultado is false)
                return NoContent();

            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirPorId(int id)
        {
            var resultado = await _pacienteService.ExcluirPorId(id);
            if (resultado is false)
                return NoContent();

            return Ok(resultado);
        }
    }
}