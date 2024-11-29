using WebApplication1.Interfaces;
using WebApplication1.Interfaces.Repository;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public class LibroService : ILibroService
    {

        private readonly LibroRepository libroRepository;

        public LibroService()
        {

            this.libroRepository = new LibroRepository();
        }

        public string DeleteLibro(int id)
        {
            return libroRepository.DeleteLibro(id);
        }

        public Libro? FindLibroById(int id)
        {
            return libroRepository.FindLibroById(id);
        }

        public List<Libro> GetAllLibros()
        {
            return libroRepository.GetAllLibros();
        }

        public string SaveLibro(Libro libro)
        {
            return libroRepository.SaveLibro(libro);
        }

        public string UpdateLibro(Libro libro)
        {
            return UpdateLibro(libro);
        }
    }
}
