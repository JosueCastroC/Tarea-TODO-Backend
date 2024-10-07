using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Interfaces;
using TodoApi.Models;

namespace TodoApi.Controllers               //Forma en la que haces las peticiones desde fuera. El Front se conecta al controlador.
{
    [Route("api/[controller]")]             //Define la ruta del controlador
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITODOMessageRepository _repository;

        public TodoController(ITODOMessageRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]                   //Acciones  
        public IActionResult ListTodos()
        {
            return Ok(_repository.ListTodos());
        }

        [HttpGet("{id:guid}")]      //Obtener
        public async Task<IActionResult> GetTodo(Guid id)
        {
            var message = await _repository.GetTodo(id);

            if (message == null)
                return NotFound();

            return Ok(message);
        }

        [HttpPost]                  //Publicar
        public async Task<IActionResult> AddTodo([FromBody] TODOMessage request)
        {
            var response = await _repository.AddTodo(request);

            return Ok(response);
        }
        [HttpPut("{id:guid}")]                   //Actualizar
        public async Task<IActionResult> UpdateTodo(Guid id, [FromBody] TODOMessage request)
        {
            var response = await _repository.UpdateTodo(request);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            var response = await _repository.DeleteTodo(id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }



    }
}
