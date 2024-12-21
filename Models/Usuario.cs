using Biblioteca.Models;
using System.Text.Json.Serialization;

namespace Biblioteca.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual string Rol { get; set; }
        public virtual int LimiteLibros { get; set; }

        [JsonIgnore]
        public ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

        public virtual void PrestarLibro(int id) { }

        public virtual void DevolverLibro(int id) { }
    }
}

public class UsuarioDto
{
    public string Nombre { get; set; }
    public string Rol { get; set; }
}


