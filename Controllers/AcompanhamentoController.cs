using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcompanhamentoPaciente.DTOs;
using AcompanhamentoPaciente.Models;
using AcompanhamentoPaciente.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AcompanhamentoPaciente.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcompanhamentoController : ControllerBase
    {
        private readonly IAcompanhamentoService _acompanhamentoService;
        public AcompanhamentoController(IAcompanhamentoService acompanhamentoService)
        {
            _acompanhamentoService = acompanhamentoService;
        }
        
        [HttpGet("lista")]
        public IActionResult BuscarTodos()
        {
            var acompanhamentos = _acompanhamentoService.BuscarTodos();
            if (acompanhamentos is null)
                return NotFound();

            return Ok(acompanhamentos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var acompanhamento = await _acompanhamentoService.BuscarPorId(id);
            if (acompanhamento is null)
                return NotFound();

            return Ok(acompanhamento);
        }

        [HttpGet("IdPaciente/{idPaciente}")]
        public IActionResult BuscarPorPaciente(int idPaciente)
        {
            var acompanhamentoPorPaciente = _acompanhamentoService.BuscarPorPaciente(idPaciente);
            if (!acompanhamentoPorPaciente.Any())
                return NotFound();
            
            return Ok(acompanhamentoPorPaciente);
        }
        
        [HttpGet("IdProfissional/{idProfissional}")]
        public IActionResult BuscarPorProfissional(int idProfissional)
        {
            var acompanhamentoPorProfissional = _acompanhamentoService.BuscarPorProfissional(idProfissional);
            if (!acompanhamentoPorProfissional.Any())
                return NotFound();

            return Ok(acompanhamentoPorProfissional); 
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarAcompanhamento(AcompanhamentoDTO acompanhamento)
        {
            var resultado = await _acompanhamentoService.AdicionarAcompanhamento(acompanhamento);
            if (resultado is false)
                return NoContent();
            
            return Ok(resultado);
        }

        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> AtualizarAcompanhamento(int id, [FromBody] Acompanhamento acompanhamento)
        {
            var resultado = await _acompanhamentoService.AtualizarAcompanhamento(id, acompanhamento);
            if (resultado is false)
                return NoContent();
            
            return Ok(resultado);
        }
    }
}