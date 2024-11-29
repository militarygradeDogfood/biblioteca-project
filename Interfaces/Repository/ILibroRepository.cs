using WebApplication1.Models;

namespace WebApplication1.Interfaces.Repository
{
    public interface ILibroRepository
    {
        List<Libro>? GetAllLibros();
        Libro? FindLibroById(int id);
        string SaveLibro(Libro libro);
        string DeleteLibro(int id);
        string UpdateLibro(Libro libro);
    }
}