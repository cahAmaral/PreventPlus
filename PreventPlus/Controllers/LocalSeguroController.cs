using Microsoft.AspNetCore.Mvc;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreventPlus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalSeguroController : ControllerBase
    {
        private readonly ILocalSeguroService _localSeguroService;

        public LocalSeguroController(ILocalSeguroService localSeguroService)
        {
            _localSeguroService = localSeguroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<LocalSeguro>>> GetAll()
        {
            var locais = await _localSeguroService.GetAllAsync();
            return Ok(locais);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LocalSeguro>> GetById(int id)
        {
            var local = await _localSeguroService.GetByIdAsync(id);
            if (local == null) return NotFound();
            return Ok(local);
        }

        [HttpPost]
        public async Task<ActionResult<LocalSeguro>> Create(LocalSeguro localSeguro)
        {
            var created = await _localSeguroService.CreateAsync(localSeguro);
            return CreatedAtAction(nameof(GetById), new { id = created.IdLocal}, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, LocalSeguro localSeguro)
        {
            var updated = await _localSeguroService.UpdateAsync(id, localSeguro);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _localSeguroService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}