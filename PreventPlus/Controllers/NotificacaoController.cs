using Microsoft.AspNetCore.Mvc;
using PreventPlus.Models;
using PreventPlus.Services;

namespace PreventPlus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacaoController : ControllerBase
    {
        private readonly INotificacaoService _notificacaoService;

        public NotificacaoController(INotificacaoService notificacaoService)
        {
            _notificacaoService = notificacaoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Notificacao>>> GetAll()
        {
            var notificacoes = await _notificacaoService.GetAllAsync();
            return Ok(notificacoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Notificacao>> GetById(int id)
        {
            var notificacao = await _notificacaoService.GetByIdAsync(id);
            if (notificacao == null) return NotFound();
            return Ok(notificacao);
        }

        [HttpPost]
        public async Task<ActionResult<Notificacao>> Create(Notificacao notificacao)
        {
            var created = await _notificacaoService.CreateAsync(notificacao);
            return CreatedAtAction(nameof(GetById), new { id = created.IdNotificacao }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Notificacao notificacao)
        {
            var updated = await _notificacaoService.UpdateAsync(id, notificacao);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _notificacaoService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}