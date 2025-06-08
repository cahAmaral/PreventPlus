using Microsoft.AspNetCore.Mvc;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreventPlus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalFavoritoController : ControllerBase
    {
        private readonly ILocalFavoritoService _localFavoritoService;

        public LocalFavoritoController(ILocalFavoritoService localFavoritoService)
        {
            _localFavoritoService = localFavoritoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<LocalFavorito>>> GetAll()
        {
            var locais = await _localFavoritoService.GetAllAsync();
            return Ok(locais);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LocalFavorito>> GetById(int id)
        {
            var local = await _localFavoritoService.GetByIdAsync(id);
            if (local == null) return NotFound();
            return Ok(local);
        }

        [HttpPost]
        public async Task<ActionResult<LocalFavorito>> Create(LocalFavorito localFavorito)
        {
            var created = await _localFavoritoService.CreateAsync(localFavorito);
            return CreatedAtAction(nameof(GetById), new { id = created.IdFav }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, LocalFavorito localFavorito)
        {
            var updated = await _localFavoritoService.UpdateAsync(id, localFavorito);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _localFavoritoService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}