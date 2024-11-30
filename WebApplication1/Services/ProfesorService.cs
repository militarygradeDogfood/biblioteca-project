using WebApplication1.Interfaces;
using WebApplication1.Interfaces.Repository;
using WebApplication1.Models;
using static WebApplication1.Models.Profesor;

namespace WebApplication1.Services
{
    public class ProfesorService : IProfesorService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILibroRepository _libroRepository;

        public ProfesorService(IUsuarioRepository usuarioRepository, ILibroRepository libroRepository)
        {
            _usuarioRepository = usuarioRepository;
            _libroRepository = libroRepository;
        }
        public bool AptoPrestar(Profesor p)
        {
            return p.getLibrosPrestados().Count < p.getLimitePrestado();
        }

        public string PrestarMaterial(Profesor profesor, Libro libro)
        {
            if (AptoPrestar(profesor))
            {
                return "El profesor ha alcanzado el límite de libros.";
            }

            if (!libro.getEstado())
            {
                return "El libro " + libro.getTitulo() + " no está disponible para ser prestado.";
            }

            libro.setEstado(false);
            profesor.getLibrosPrestados().Add(libro);

            return "El libro " + libro.getTitulo() + " ha sido prestado al Profesor.";

        }

        public string DevolverMaterial(Profesor profesor, Libro libro)
        {
            if (!profesor.getLibrosPrestados().Contains(libro))
            {
                return "El libro " + libro.getTitulo() + " no está prestado a este Profesor.";
            }

            libro.setEstado(true);
            profesor.getLibrosPrestados().Remove(libro);
            return "El libro " + libro.getTitulo() + " ha sido devuelto.";
        }

    }
}
