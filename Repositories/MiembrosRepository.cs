using Microsoft.AspNetCore.Http.HttpResults;
using TodoApi.Interfaces;
using TodoApi.Models;

public class MiembrosRepository : IMiembrosRepository
{
    private readonly TODODbContext _db;

    public MiembrosRepository(TODODbContext db)
    {
        _db = db;

    }

    public async Task<Miembros> ActualizarMiembro(Miembros request)
    {
        _db.Miembros.Update(request);
        _db.SaveChanges();
        return request;
    }

    public async Task<Miembros> AñadirMiembro(Miembros request)
    {
        _db.Miembros.Add(request);
        _db.SaveChanges();
        return request;
    }

    public async Task<Miembros?> EliminarMiembroPorId(Guid id)
    {
        var miembroEncontrado = _db.Miembros.Find(id);
        if (miembroEncontrado == null)
        {
            return null;
        }
        _db.Miembros.Remove(miembroEncontrado);
        _db.SaveChanges();
        return miembroEncontrado;
    }

    public List<Miembros> ObetenerTodosMiembros()
    {
        var message = _db.Miembros.ToList();
        return message;
    }

    public async Task<Miembros> ObtenerMiembroPorId(Guid id)
    {
        return await _db.Miembros.FindAsync(id);
    }
}