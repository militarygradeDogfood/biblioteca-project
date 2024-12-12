using System.Data;
using WebApplication1.Interfaces;
using WebApplication1.Interfaces.Repository;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public class LibroService : ILibroService
    {
        private readonly DapperContext _context;
        private readonly IDbConnection _connectionString;
        private readonly LibroRepository libroRepository;

        public LibroService(DapperContext context)
        {
            this._context = context;
            _connectionString = context.CreateConnection();
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
            Console.WriteLine("Getting Libros");
            return libroRepository.GetAllLibros();
        }

        public void SaveLibro(Libro libro)
        {
            libroRepository.InsertLibro(libro);
        }

        public string UpdateLibro(Libro libro)
        {
            return UpdateLibro(libro);
        }
    }
}
