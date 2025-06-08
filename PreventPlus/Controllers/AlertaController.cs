using Microsoft.AspNetCore.Mvc;
using PreventPlus.Models;
using PreventPlus.Services;

namespace PreventPlus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertaController : ControllerBase
    {
        private readonly IAlertaService _alertaService;

        public AlertaController(IAlertaService alertaService)
        {
            _alertaService = alertaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Alerta>>> GetAll()
        {
            var alertas = await _alertaService.GetAllAsync();
            return Ok(alertas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Alerta>> GetById(int id)
        {
            var alerta = await _alertaService.GetByIdAsync(id);
            if (alerta == null) return NotFound();
            return Ok(alerta);
        }

        [HttpPost]
        public async Task<ActionResult<Alerta>> Create(Alerta alerta)
        {
            var created = await _alertaService.CreateAsync(alerta);
            return CreatedAtAction(nameof(GetById), new { id = created.IdAlerta }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Alerta alerta)
        {
            var updated = await _alertaService.UpdateAsync(id, alerta);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _alertaService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}