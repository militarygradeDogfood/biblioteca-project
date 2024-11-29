using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class Estudiante : Usuario
    {
        private const int limitePrestado = 3;

        public Estudiante(int id, string nombre)
            : base(id, nombre, "Estudiante")
        {
        }

        public int getLimitePrestado()
        {
            return limitePrestado;
        }
    }

    }
