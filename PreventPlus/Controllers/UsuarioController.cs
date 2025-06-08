using Microsoft.AspNetCore.Mvc;
using PreventPlus.Models;

using System.Collections.Generic;
using System.Threading.Tasks;
using PreventPlus.Services;


[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Usuario>>> GetAll() => Ok(await _usuarioService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetById(int id)
    {
        var item = await _usuarioService.GetByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<Usuario>> Create(Usuario usuario)
    {
        var created = await _usuarioService.CreateAsync(usuario);
        return CreatedAtAction(nameof(GetById), new { id = created.IdUsuario }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Usuario usuario)
    {
        var updated = await _usuarioService.UpdateAsync(id, usuario);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _usuarioService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}