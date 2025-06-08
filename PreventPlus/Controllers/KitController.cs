using Microsoft.AspNetCore.Mvc;
using PreventPlus.Models;
using PreventPlus.Services;

namespace PreventPlus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KitController : ControllerBase
    {
        private readonly IKitService _kitService;

        public KitController(IKitService kitService)
        {
            _kitService = kitService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Kit>>> GetAll()
        {
            var kits = await _kitService.GetAllAsync();
            return Ok(kits);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Kit>> GetById(int id)
        {
            var kit = await _kitService.GetByIdAsync(id);
            if (kit == null) return NotFound();
            return Ok(kit);
        }

        [HttpPost]
        public async Task<ActionResult<Kit>> Create(Kit kit)
        {
            var created = await _kitService.CreateAsync(kit);
            return CreatedAtAction(nameof(GetById), new { id = created.IdKit }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Kit kit)
        {
            var updated = await _kitService.UpdateAsync(id, kit);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _kitService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}