using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IBookService
    {
        Book? FindBookByIsbn(string isbn);
        void RegisterBook();
    }
}