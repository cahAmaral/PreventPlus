using Microsoft.AspNetCore.Mvc;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreventPlus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoricoRiscoController : ControllerBase
    {
        private readonly IHistoricoRiscoService _historicoRiscoService;

        public HistoricoRiscoController(IHistoricoRiscoService historicoRiscoService)
        {
            _historicoRiscoService = historicoRiscoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<HistoricoRisco>>> GetAll()
        {
            var historicos = await _historicoRiscoService.GetAllAsync();
            return Ok(historicos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HistoricoRisco>> GetById(int id)
        {
            var historico = await _historicoRiscoService.GetByIdAsync(id);
            if (historico == null) return NotFound();
            return Ok(historico);
        }

        [HttpPost]
        public async Task<ActionResult<HistoricoRisco>> Create(HistoricoRisco historicoRisco)
        {
            var created = await _historicoRiscoService.CreateAsync(historicoRisco);
            return CreatedAtAction(nameof(GetById), new { id = created.IdHistorico}, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, HistoricoRisco historicoRisco)
        {
            var updated = await _historicoRiscoService.UpdateAsync(id, historicoRisco);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _historicoRiscoService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}