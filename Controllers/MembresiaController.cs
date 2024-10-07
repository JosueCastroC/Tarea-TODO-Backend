using Microsoft.AspNetCore.Mvc;
using TodoApi.Interfaces;
using TodoApi.Models;

[Route("api/[controller]")]
[ApiController]

public class MembresiaController : ControllerBase
{
    private readonly IMembresiaRepository membresiaRepository;
    public MembresiaController(IMembresiaRepository repository)
    {
        membresiaRepository = repository;
    }

    [HttpGet]   
    public IActionResult ObtenerTodasMembresias()
    {
        return Ok(membresiaRepository.ObtenerTodasLasMembresias()); 
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> ObtenerMembresiaPorId(Guid id)
    {
        var membresiaEncontrada = await membresiaRepository.ObtenerMembresiaPorId(id);
        if(membresiaEncontrada == null)
        {
            return NotFound();
        }
        return Ok(membresiaEncontrada);
    }

    [HttpPost]
    public async Task<IActionResult>RegistrarNuevaMembresia(Membresia request)
    {
        var NuevaMembresia = membresiaRepository.AñadirMembresia(request);
        return Ok(NuevaMembresia);
    }

    [HttpPut]
    public async Task<IActionResult>ActualizarMembresia([FromBody] Membresia request)
    {
        var membresiaActualizada = membresiaRepository.ActualizarMembresia(request);
        return Ok(membresiaActualizada);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult>EliminarMembresia(Guid id)
    {
        var membresiaEncontrada = await membresiaRepository.ObtenerMembresiaPorId(id);
        if(membresiaEncontrada == null)
        {
            return NotFound();
        }
        return Ok(membresiaRepository.EliminarMembresiaPorId(id));
    }
}