using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IUserService
    {
        void DeleteUser(int id);
        void DevolverMaterial();
        User? FindUserById(int id);
        List<User> GetAllUsers();
        List<Book>? getBorrowedBooks(int id);
        void PrestarMaterial();
        void RegisterUser(string name, string role);
        void UpdateUser(User user);
    }
}