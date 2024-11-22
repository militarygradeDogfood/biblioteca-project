using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WebApplication1.Models.Book;

namespace WebApplication1.Models
{
    public class User
    {
        [Key]
        private int id { get; set; }
        private static int idCounter = 1;
        private string name { get; set; }
        private List<Book> borrowedBooks { get; set; }
        private string role;


        public User(string name, string role)
        {
            this.id = idCounter++;
            this.name = name;
            this.role = role;
            this.borrowedBooks = new List<Book>();
        }

        public User()
        {
            this.id = idCounter++;
            this.name = "";
            borrowedBooks = new List<Book>();
            this.role = "";
        }
        public int getId()
        {
            return this.id;
        }

        public string getName() { return this.name; }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setRole(string role)
        {
            this.role = role;
        }

        public string getRole()
        {
            return role;
        }

        public List<Book> getBorrowedBooks()
        {
            return borrowedBooks;
        }
    }
}
