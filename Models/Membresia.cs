namespace TodoApi.Models
{
    public class Membresia
    {
        public Guid Id { get; set; }
        public required string TipoDeMembresia { get; set; }
        public required bool EstaActiva { get; set; }   
        public required int MesesDeSuscripcion { get; set; }

    }
}