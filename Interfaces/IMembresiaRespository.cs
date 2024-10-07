using TodoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Interfaces            //Lista las operaciones que hara mi repositorio.
{
    public interface IMembresiaRepository
    {
        List<Membresia> ObtenerTodasLasMembresias();
        Task<Membresia> ObtenerMembresiaPorId(Guid id);
        Task<Membresia> AñadirMembresia(Membresia request);
        Task<Membresia> ActualizarMembresia(Membresia request);

        Task<Membresia> EliminarMembresiaPorId(Guid id);


    }
}