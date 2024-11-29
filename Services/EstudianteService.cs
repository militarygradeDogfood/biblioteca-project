using WebApplication1.Interfaces;
using WebApplication1.Interfaces.Repository;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class EstudianteService : IEstudianteService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILibroRepository _libroRepository;

        public EstudianteService(IUsuarioRepository usuarioRepository, ILibroRepository libroRepository)
        {
            _usuarioRepository = usuarioRepository;
            _libroRepository = libroRepository;
        }

        public bool AptoPrestar(Estudiante e)
        {
            return e.getLibrosPrestados().Count < e.getLimitePrestado();
        }

        public string PrestarMaterial(Estudiante estudiante, Libro libro)
        {
            if (AptoPrestar(estudiante)) { 
                return "El estudiante ha alcanzado el límite de libros.";
            }

            if(!libro.getEstado())
            {
                return "El libro no está disponible para ser prestado.";
            }

            libro.setEstado(false);
            estudiante.getLibrosPrestados().Add(libro);

            return "El libro " + libro.getTitulo() + " ha sido prestado al Estudiante.";

        }

        public string DevolverMaterial(Estudiante estudiante, Libro libro)
        {
            if(!estudiante.getLibrosPrestados().Contains(libro))
            {
                return "El libro " + libro.getTitulo() + " no está prestado a este estudiante.";
            }

            libro.setEstado(true);
            estudiante.getLibrosPrestados().Remove(libro);
            return "El libro " + libro.getTitulo() + " ha sido devuelto.";
        }
    }
}
