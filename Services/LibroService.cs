using Biblioteca.Data;
using Biblioteca.Models;

namespace Biblioteca.Services
{
    public class LibroService
    {
        private readonly LibroRepository _repository;

        public LibroService(LibroRepository repository)
        {
            _repository = repository;
        }

        public Libro GetLibroById(int id)
        {
            return _repository.GetLibroById(id);
        }

        public IEnumerable<Libro> GetAllLibros()
        {
            return _repository.GetAllLibros();
        }

        public bool InsertLibro(LibroDto libroDto)
        {
            return _repository.InsertLibro(libroDto);
        }

        public bool UpdateLibro(Libro libro)
        {
            return _repository.UpdateLibro(libro);
        }

        public bool DeleteLibro(int id)
        {
            return _repository.DeleteLibro(id);
        }
    }
}
