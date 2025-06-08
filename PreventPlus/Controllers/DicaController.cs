using Microsoft.AspNetCore.Mvc;
using PreventPlus.Models;
using PreventPlus.Services;

namespace PreventPlus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DicaController : ControllerBase
    {
        private readonly IDicaService _dicaService;

        public DicaController(IDicaService dicaService)
        {
            _dicaService = dicaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Dica>>> GetAll()
        {
            var dicas = await _dicaService.GetAllAsync();
            return Ok(dicas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dica>> GetById(int id)
        {
            var dica = await _dicaService.GetByIdAsync(id);
            if (dica == null) return NotFound();
            return Ok(dica);
        }

        [HttpPost]
        public async Task<ActionResult<Dica>> Create(Dica dica)
        {
            var created = await _dicaService.CreateAsync(dica);
            return CreatedAtAction(nameof(GetById), new { id = created.IdDica }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Dica dica)
        {
            var updated = await _dicaService.UpdateAsync(id, dica);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _dicaService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}