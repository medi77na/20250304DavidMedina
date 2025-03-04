using Crecer.Dtos;
using Crecer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crecer.Controllers
{
    [ApiController]
    [Route("api/v1/estudiantes")]
    [Tags("Estudiantes")]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteService _estudianteService;

        public EstudianteController(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var estudiante = await _estudianteService.ObtenerPorId(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            return Ok(estudiante);
        }

        [HttpGet("codigo/{codigo}")]
        public async Task<IActionResult> ObtenerPorCodigo(string codigo)
        {
            var estudiante = await _estudianteService.ObtenerPorCodigo(codigo);
            if (estudiante == null)
            {
                return NotFound();
            }
            return Ok(estudiante);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var estudiantes = await _estudianteService.ObtenerTodos();
            return Ok(estudiantes);
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] EstudiantePostDto EstudiantePostDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _estudianteService.Agregar(EstudiantePostDto);
            return CreatedAtAction(nameof(ObtenerPorId), new { codigo = EstudiantePostDto.Codigo }, EstudiantePostDto);
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] EstudiantePostDto estudianteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _estudianteService.Actualizar(estudianteDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _estudianteService.Eliminar(id);
            return NoContent();
        }
    }
}
