using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using WebApplication1.Interfaces.Repository;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Repository
{
    public class LibroRepository : ILibroRepository
    {
        private readonly DapperContext _context;

        private LibroService libroService;
        private List<Libro> libros;

        public LibroRepository(DapperContext context)
        {

            _context = context;

            this.libros = new List<Libro>();

            //ejemplo
            Libro libro = new Libro(1, "autor", "titulo", "asdf1234");
            libros.Add(libro);
        }

        public LibroRepository()
        {
        }

        public string DeleteLibro(int id)
        {
            Libro libro = FindLibroById(id);
            if (libro != null)
            {
                libros.Remove(libro);
                return "Libro eliminado correctamente.";
            }
            return "El libro está vacío";
        }

        public Libro? FindLibroById(int id)
        {
            foreach (var libro in libros)
            {
                if (libro.getId() == id)
                {
                    return libro;
                }
            }

            return null;
        }

        //filtrar sólo por los libros con estado true, ya que son los disponibles

        public List<Libro>? GetAllLibros()
        {
            if (libros == null)
            {
                return null;
            }

            return libros;
        }
        public string SaveLibro(Libro libro)
        {
            if (libro == null)
            {
                return "El libro está vacío.";
            }
            libros.Add(libro);
            return "Usuario registrado correctamente.";
        }

        public string UpdateLibro(Libro libro)
        {
            Libro libroExistente = FindLibroById(libro.getId());
            if (libroExistente != null)
            {
                libro.setTitulo(libro.getAutor());
                libro.setAutor(libro.getTitulo());
                return "Libro modificado correctamente.";
            }
            else
            {
                return "Libro no encontrado.";
            }
        }

        public void InsertLibro(Libro libro)
        {
            using (var connection = _context.CreateConnection())
            {
                try
                {
                    // Aquí hacemos la inserción usando Dapper
                    var sql = @"
                    INSERT INTO Libros(autor, titulo, isbn, estado)
                    VALUES (@autor, @titulo, @isbn, @estado)";

                    var rowsAffected = connection.Execute(sql, new
                    {
                        autor = libro.getAutor(),
                        titulo = libro.getTitulo(),
                        isbn = libro.getIsbn(),
                        estado = libro.getEstado()
                    });

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Libro insertado correctamente: {0}", libro.ToString());
                    }
                    else
                    {
                        Console.WriteLine("No se insertaron registros para el libro: {0}", libro.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error inesperado en InsertLibro para el libro: {0}", libro.ToString());
                    Console.WriteLine(ex.Message);
                }
            }
        }


        public IEnumerable<Libro> GetAllLibrosDapper()
        {
            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var sql = @"
                SELECT 
                    libro.Id,
                    libro.Autor,
                    libro.Titulo,
                    libro.Isbn,
                    libro.Estado
                FROM
                    Libro libro";

                    return libros;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error ejecutando consulta SQL en GetAllLibrosDapper");
                    return Enumerable.Empty<Libro>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error inesperado en GetAllLibrosDapper");
                    return Enumerable.Empty<Libro>();
                }
            }

            string UpdateLibroDapper(Libro libro)
            {
                using (var connection = _context.CreateConnection())
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            var sql = @"
                            UPDATE Libro
                            SET Autor = @Autor, Titulo = @Titulo, Isbn = @Isbn, Estado = @Estado
                            WHERE Id = @Id";

                            var rowsAffected = connection.Execute(sql, libro, transaction);

                            if (rowsAffected == 0)
                            {
                                Console.WriteLine("No se encontró un libro con el id {id} para actualizar", libro.id);
                                return $"No se encontró un libro con el id {libro.id} para actualizar";
                            }

                            transaction.Commit();
                            Console.WriteLine("Libro con id {id} actualizado correctamente. {RowsAffected} registros afectados", libro.id, rowsAffected);
                            return $"Se afectaron {rowsAffected} registros";
                        }
                        catch (SqlException sqlEx)
                        {
                            transaction.Rollback();
                            Console.WriteLine("Error ejecutando consulta SQL en UpdateLibro para el producto: {@Libro}", libro);
                            throw new Exception("Ocurrió un error al actualizar el libro. Por favor, intente nuevamente", sqlEx);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine("Error inesperado en UpdateLibro para el producto: {@Libro}", libro);
                            throw new Exception("Ocurrió un error inesperado al actualizar el producto. Por favor intente nuvamente", ex);


                        }
                    }
                }


                string DeleteLibroDapper(int id)
                {
                    using (var connection = _context.CreateConnection())
                    {
                        try
                        {
                            var sql = "DELETE FROM Libros WHERE Id = @Id";
                            var rowsAffected = connection.Execute(sql, new { Id = id });
                            if (rowsAffected == 0)
                            {
                                Console.WriteLine("No se encontró un libro con el id {Id} para eliminar", id);
                                return $"No se encontró un libro con el id {id} para eliminar";
                            }

                            Console.WriteLine("Libro con id {Id} eliminado correctamente", id);
                            return "Eliminado correctamente";
                        }
                        catch (SqlException sqlEx)
                        {
                            Console.WriteLine("Error ejecutando consulta SQL en DeleteLibroDapper para el id {Id}", id);
                            throw new Exception("Ocurrió un error al eliminar el libro. Por favor, intente nuevamente.", sqlEx);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error inesperado en DeleteLibroDapper para el id {Id}", id);
                            throw new Exception("Ocurrió un error inesperado al eliminar el libro. Por favor, intente nuevamente");
                        }
                    }
                }
            }
        }

        void ILibroRepository.SaveLibro(Libro libro)
        {
            throw new NotImplementedException();
        }
    }
}
