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
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _cargoService;

        public CargoController(ICargoService cargoService)
        {   
            _cargoService = cargoService;
        }

        [HttpGet("lista")]
        public async Task<IActionResult> Buscar()
        {
            var cargos = await _cargoService.BuscarTodos();
            if (cargos is null)
                return NotFound();

            return Ok(cargos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPaciente(int id)
        {
            var cargo = await _cargoService.BuscarPorId(id);
            if (cargo is null)
                return NotFound();
            
            return Ok(cargo);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Cargo cargo)
        {
            var resultado = await _cargoService.Adicionar(cargo);
            if (resultado is false)
                return NoContent();

            return Ok(resultado);
        }

        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Cargo cargo)
        {
            var resultado = await _cargoService.Atualizar(id, cargo);
            if (resultado is false)
                return NoContent();

            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirPorId(int id)
        {
            var resultado = await _cargoService.ExcluirPorId(id);
            if (resultado is false)
                return NoContent();

            return Ok(resultado);
        }
    }
}