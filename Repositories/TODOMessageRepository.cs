using Microsoft.EntityFrameworkCore;
using TodoApi.Interfaces;
using TodoApi.Models;

namespace TodoApi.Repositories          //Define la logica de las operaciones
{
    public class TODOMessageRepository : ITODOMessageRepository
    {
        private readonly TODODbContext _db;

        public TODOMessageRepository(TODODbContext db)
        {
            _db = db;

        }

        public async Task<TODOMessage> AddTodo(TODOMessage request)
        {
            _db.Todos.Add(request);
            _db.SaveChanges();

            return request;
        }

        public async Task<TODOMessage?> DeleteTodo(Guid id)
        {
            var messageFound = _db.Todos.Find(id);
            if (messageFound == null)
            {
                return null;
            }

            _db.Remove(messageFound);
            _db.SaveChanges();

            return messageFound;
        }

        public async Task<TODOMessage> GetTodo(Guid id)
        {
            var message = await _db.Todos.FindAsync(id);

            return message;
        }

        public List<TODOMessage> ListTodos()
        {
            List<TODOMessage> messages = _db.Todos.ToList();

            return messages;
        }

        public async Task<TODOMessage> UpdateTodo(TODOMessage request)
        {
            var messageFound = await _db.Todos.FindAsync(request.Id);
            if (messageFound == null)
            {
                return null;
            }
            _db.Todos.Update(request);
            _db.SaveChanges();

            return request;
        }

    }
}
