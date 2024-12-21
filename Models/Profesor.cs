namespace Biblioteca.Models
{
    public class Profesor : Usuario
    {
        public override string Rol { get; set; } = "Profesor";
        public override int LimiteLibros { get; set; } = 5;
    }
}
