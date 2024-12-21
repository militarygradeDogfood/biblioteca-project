using System.Text.Json.Serialization;

namespace Biblioteca.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Autor {  get; set; }
        public string Titulo { get; set; }
        public string Isbn { get; set; }
        public bool Estado { get; set; } = false;
        [JsonIgnore]
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
public class LibroDto
{
    public string Autor { get; set; }
    public string Titulo { get; set; }
    public string Isbn { get; set; }
}
