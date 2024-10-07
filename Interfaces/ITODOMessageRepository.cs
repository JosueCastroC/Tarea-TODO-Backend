using TodoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Interfaces            //Lista las operaciones que hara mi repositorio.
{
    public interface ITODOMessageRepository
    {
        List<TODOMessage> ListTodos();      //Busca todos los todo's
        Task<TODOMessage> GetTodo(Guid id); //Busca un solo Todo por Id
        Task<TODOMessage> AddTodo(TODOMessage request);
        Task<TODOMessage> UpdateTodo(TODOMessage request);
        Task<TODOMessage?> DeleteTodo(Guid id);

    }
}
