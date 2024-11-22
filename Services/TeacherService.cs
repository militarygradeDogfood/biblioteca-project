using WebApplication1.Models;
using static WebApplication1.Models.Teacher;

namespace WebApplication1.Services
{
    public class TeacherService
    {
        private List<Teacher> teachers;

        public TeacherService()
        {
            teachers = new List<Teacher>();
        }
        public void ExtendBorrow(int id, int extendValue)
        {
            Teacher teacher = findTeacherById(id);
            if(teacher != null)
            {
                teacher.setExtendBorrow(true);
                teacher.setBorrowLimit(extendValue);
                Console.WriteLine("El límite de préstamo se ha extendido.");
            } else
            {
                Console.WriteLine("El profesor ingresado no existe.");
            }
        }

        public void PrestarMaterial(int id, Book book) {
            Teacher teacher = findTeacherById(id);
            if(teacher.getBorrowedBooks().Count() < teacher.getBorrowLimit())
            {
                teacher.getBorrowedBooks().Add(book);
                book.setEstado(true);
                Console.WriteLine("El libro" + book.getTitle() + " ha sido prestado al profesor.");
            } else
            {
                Console.WriteLine("El límite de libros del profesor ha sido alcanzado.");
            }

        }

        public void DevolverMaterial(int id, Book book)
        {
            Teacher teacher = findTeacherById(id);
            
            if(teacher.getBorrowedBooks().Remove(book))
            {
                book.setEstado(false);
                Console.WriteLine("El libro" + book.getTitle() + " ha sido devuelto.");
            }
            else
            {
                Console.WriteLine("El libro no está prestado a este profesor.");
            }
        
        }

        public Teacher? findTeacherById(int id)
        {
            foreach (var teacher in teachers)
            {
                if (teacher.getRole() == "Teacher" && teacher.getId() == id)
                {
                    return teacher;
                }
            }

            return null;
        }

    }
}
