using Microsoft.AspNetCore.Mvc;
using TodoApi.Interfaces;
using TodoApi.Models;

[Route("api/[controller]")]
[ApiController]
public class MiembrosController : ControllerBase
{
    private readonly IMiembrosRepository _repository;

    public MiembrosController(IMiembrosRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult ObtenerTodosMiembros()
    {
        return Ok(_repository.ObetenerTodosMiembros());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> ObtenerMiembroPorId(Guid id)
    {
        var miembroEncontrado = await _repository.ObtenerMiembroPorId(id);
        if(miembroEncontrado == null)
        {
            return NotFound(); 
        }
        return Ok(miembroEncontrado);
    }

    [HttpPost]
    public async Task<IActionResult>RegistrarNuevoMiembro(Miembros request)
    {
        var NuevoMiembro = _repository.AñadirMiembro(request);
        return Ok(NuevoMiembro);    
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult>ActualizarMiembro(Guid id, [FromBody] Miembros request)
    {
        var miembroActualizado = _repository.ActualizarMiembro(request);
        return Ok(miembroActualizado);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult>EliminarMiembro(Guid id)
    {
        var miembroEncontrado = await _repository.ObtenerMiembroPorId(id);
        if(miembroEncontrado == null) 
        { 
            return NotFound(); 
        }
        return Ok(_repository.EliminarMiembroPorId(id));
    }
}