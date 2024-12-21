namespace Biblioteca.Models
{
    public class Estudiante : Usuario
    {
        public override string Rol { get; set; } = "Estudiante";
        public override int LimiteLibros { get; set; } = 3;
    }
}
