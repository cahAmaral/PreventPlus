using Microsoft.AspNetCore.Mvc;
using PreventPlus.Models;
using PreventPlus.Services;

namespace PreventPlus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChecklistController : ControllerBase
    {
        private readonly IChecklistService _checklistService;

        public ChecklistController(IChecklistService checklistService)
        {
            _checklistService = checklistService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Checklist>>> GetAll()
        {
            var checklists = await _checklistService.GetAllAsync();
            return Ok(checklists);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Checklist>> GetById(int id)
        {
            var checklist = await _checklistService.GetByIdAsync(id);
            if (checklist == null) return NotFound();
            return Ok(checklist);
        }

        [HttpPost]
        public async Task<ActionResult<Checklist>> Create(Checklist checklist)
        {
            var created = await _checklistService.CreateAsync(checklist);
            return CreatedAtAction(nameof(GetById), new { id = created.IdChecklist }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Checklist checklist)
        {
            var updated = await _checklistService.UpdateAsync(id, checklist);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _checklistService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}