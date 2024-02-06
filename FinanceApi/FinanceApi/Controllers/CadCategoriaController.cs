using FinanceApi.Models;
using FinanceApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CadCategoriaController : ControllerBase
    {
        private readonly CadCategoriaService _cadCategoriaService;

        public CadCategoriaController(CadCategoriaService cadCategoriaService)
        {
            _cadCategoriaService = cadCategoriaService;
        }

        [HttpGet]
        public async Task<List<CadCategoria>> Get()
        {
            List<CadCategoria> categoria = await _cadCategoriaService.GetCategoriaAsync();
            return categoria;
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<CadCategoria>> Get(string id)
        {
            var categoria = await _cadCategoriaService.GetCategoriaAsync(id);
            return categoria;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CadCategoria newCategoria)
        {
            await _cadCategoriaService.CreateCategoriaAsync(newCategoria);
            return CreatedAtAction(nameof(Get), new { id = newCategoria.Id }, newCategoria);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, CadCategoria updateCategoria)
        {
            var categoria = await _cadCategoriaService.GetCategoriaAsync(id);

            updateCategoria.NomeCategoria = categoria.NomeCategoria;
            updateCategoria.AtividadeCategoria = categoria.AtividadeCategoria;
            updateCategoria.TipoCategoria = categoria.TipoCategoria;

            await _cadCategoriaService.UpdateCategoriaAsync(id, updateCategoria);

            return Ok(new
            {
                categoria.Id,
                categoria.TipoCategoria,
                categoria.AtividadeCategoria,
                categoria.NomeCategoria,
            });
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var categoria = await _cadCategoriaService.GetCategoriaAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            await _cadCategoriaService.RemoveCategoriaAsync(id);
            return NoContent();
        }
    }
}
