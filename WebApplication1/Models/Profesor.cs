using System.Data;

namespace WebApplication1.Models
{
    public class Profesor : Usuario
    {
        private const int limitePrestado = 5;

        public Profesor(int id, string nombre)
            : base(id, nombre, "Profesor")
        {
        }

        public int getLimitePrestado()
        {
            return limitePrestado;
        }
    }
}
