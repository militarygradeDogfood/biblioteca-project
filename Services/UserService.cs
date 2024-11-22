using System.Data;
using System.Xml.Linq;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using static WebApplication1.Models.Book;
using static WebApplication1.Models.User;

namespace WebApplication1.Services
{
    public class UserService : IUserService
    {
        private BookService bookService;
        private List<User> users;

        public UserService()
        {
            User user = new User("nombre", "adm");
            users = new List<User>();
            users.Add(user);
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public List<Book>? getBorrowedBooks(int id)
        {
            User user = FindUserById(id);
            if (user != null)
            {
                return user.getBorrowedBooks();
            }
            return null;
        }

        public void RegisterUser(string name, string role)
        {
            User newUser = new User(name, role);
            users.Add(newUser);
            Console.WriteLine("Usuario registrado correctamente.");
        }

        public User? FindUserById(int id)
        {
            foreach (var user in users)
            {
                if (user.getId() == id)
                {
                    return user;
                }
            }

            return null;
        }

        public void DeleteUser(int id)
        {
            User user = FindUserById(id);
            if (user != null)
            {
                users.Remove(user);
            }
        }

        public void PrestarMaterial() { }
        public void DevolverMaterial() { }

        public void UpdateUser(User user)
        {
            users.Add(user);
        }
    }
}
