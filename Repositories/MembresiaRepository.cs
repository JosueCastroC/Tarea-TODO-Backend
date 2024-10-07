using TodoApi.Interfaces;
using TodoApi.Models;

public class MembresiaRepository : IMembresiaRepository
{
    private readonly TODODbContext _db;
    public MembresiaRepository(TODODbContext db)
    {
        _db = db;
    }
    public async Task<Membresia> ActualizarMembresia(Membresia request)
    {
        _db.Membresia.Update(request);
        _db.SaveChanges();
        return request;
    }

    public async Task<Membresia> AñadirMembresia(Membresia request)
    {
        _db.Membresia.Add(request);
        _db.SaveChanges();
        return request;
    }

    public async Task<Membresia?> EliminarMembresiaPorId(Guid id)
    {
        var membresiaEncontrada = _db.Membresia.Find(id);
        if(membresiaEncontrada == null)
        {
            return null;
        }
        _db.Membresia.Remove(membresiaEncontrada);
        _db.SaveChanges();
        return membresiaEncontrada;
    }

    public List<Membresia> ObtenerTodasLasMembresias()
    {
        var TodasLasMembresias = _db.Membresia.ToList();
        return TodasLasMembresias;  

    }

    public Task<Membresia> ObtenerMembresiaPorId(Guid id)
    {
        throw new NotImplementedException();
    }
}