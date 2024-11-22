using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class StudentService
    {
        private List<Student> students;

        public StudentService()
        {
            students = new List<Student>();
        }
        /*
        public Student? FindStudentById(int id)
        {
            foreach (var student in students)
            {
                if (student.getRole() == "Student" && student.getId() == id)
                {
                    return student;
                }
            }

            return null;
        }*/

        /*
        public void PrestarMaterial(int id, Book book)
        {
            Student student = FindStudentById(id);

            if (student.getBorrowedBooks().Count() < student.getBorrowLimit())
            {
                student.getBorrowedBooks().Add(book);
                book.setEstado(true);
                Console.WriteLine("El libro" + book.getTitle() + " ha sido prestado al estudiante.");
            } else
            {
                Console.WriteLine("El estudiante ha alcanzado el límite de libros.");
            }

        }

        public void DevolverMaterial(int id, Book book)
        {
            Student student = FindStudentById(id);
            if (student.getBorrowedBooks().Remove(book))
            {
                book.setEstado(false);
                Console.WriteLine("El libro" + book.getTitle() + " ha sido devuelto.");
            } else
            {
                Console.WriteLine("El libro no está prestado a este estudiante.");
            }
        }*/
    }
}
