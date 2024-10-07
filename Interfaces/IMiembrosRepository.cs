using TodoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Interfaces            //Lista las operaciones que hara mi repositorio.
{
    public interface IMiembrosRepository
    {
        List<Miembros> ObetenerTodosMiembros();
        Task<Miembros> ObtenerMiembroPorId(Guid id);
        Task<Miembros> AñadirMiembro(Miembros request);
        Task<Miembros> ActualizarMiembro(Miembros request);

        Task<Miembros> EliminarMiembroPorId(Guid id);


    }
}