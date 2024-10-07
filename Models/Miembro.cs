namespace TodoApi.Models
{
    public class Miembros
    {
        public Guid Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }

    }
}