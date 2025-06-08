using Microsoft.AspNetCore.Mvc;
using PreventPlus.Models;
using PreventPlus.Services;

namespace PreventPlus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegiaoController : ControllerBase
    {
        private readonly IRegiaoService _regiaoService;

        public RegiaoController(IRegiaoService regiaoService)
        {
            _regiaoService = regiaoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Regiao>>> GetAll()
        {
            var regioes = await _regiaoService.GetAllAsync();
            return Ok(regioes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Regiao>> GetById(int id)
        {
            var regiao = await _regiaoService.GetByIdAsync(id);
            if (regiao == null) return NotFound();
            return Ok(regiao);
        }

        [HttpPost]
        public async Task<ActionResult<Regiao>> Create(Regiao regiao)
        {
            var created = await _regiaoService.CreateAsync(regiao);
            return CreatedAtAction(nameof(GetById), new { id = created.IdRegiao }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Regiao regiao)
        {
            var updated = await _regiaoService.UpdateAsync(id, regiao);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _regiaoService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}