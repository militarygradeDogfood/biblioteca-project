using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Prestamo
    {
        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public int LibroId { get; set; }
        public virtual Libro Libro { get; set; }

        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }

        public string EstadoPrestamo { get; set; }
    }
}
