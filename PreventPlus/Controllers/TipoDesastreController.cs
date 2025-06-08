using Microsoft.AspNetCore.Mvc;
using PreventPlus.Models;
using PreventPlus.Services;

namespace PreventPlus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoDesastreController : ControllerBase
    {
        private readonly ITipoDesastreService _tipoDesastreService;

        public TipoDesastreController(ITipoDesastreService tipoDesastreService)
        {
            _tipoDesastreService = tipoDesastreService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoDesastre>>> GetAll()
        {
            var tipos = await _tipoDesastreService.GetAllAsync();
            return Ok(tipos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDesastre>> GetById(int id)
        {
            var tipo = await _tipoDesastreService.GetByIdAsync(id);
            if (tipo == null) return NotFound();
            return Ok(tipo);
        }

        [HttpPost]
        public async Task<ActionResult<TipoDesastre>> Create(TipoDesastre tipoDesastre)
        {
            var created = await _tipoDesastreService.CreateAsync(tipoDesastre);
            return CreatedAtAction(nameof(GetById), new { id = created.IdDesastre }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TipoDesastre tipoDesastre)
        {
            var updated = await _tipoDesastreService.UpdateAsync(id, tipoDesastre);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _tipoDesastreService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}