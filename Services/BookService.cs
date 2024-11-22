using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class BookService : IBookService
    {
        private List<Book> books;

        public BookService()
        {
            books = new List<Book>();
        }

        public Book? FindBookByIsbn(string isbn)
        {
            foreach (var book in books)
            {
                if (book.getIsbn() == isbn)
                {
                    return book;
                }
            }
            return null;
        }

        public void RegisterBook()
        {
            Console.Write("Ingrese el autor del libro: ");
            string bookAuthor = Console.ReadLine();

            Console.Write("Ingrese el título del libro: ");
            string bookTitle = Console.ReadLine();

            Console.Write("Ingrese el ISBN del libro: ");
            string bookIsbn = Console.ReadLine();

            Book newBook = new Book(bookAuthor, bookTitle, bookIsbn);
            books.Add(newBook);
            Console.WriteLine("Libro creado con éxito");

        }
    }
}
