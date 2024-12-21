using Biblioteca.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Biblioteca.Data
{
    public class LibroRepository
    {
        private readonly DapperContext _context;
        public LibroRepository(DapperContext context)
        {
            _context = context;
        }

        public Libro GetLibroById(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var sql = @"SELECT ID, Autor, Titulo, Isbn, Estado FROM Libros WHERE ID = @Id";
                    var libro = connection.QueryFirstOrDefault<Libro>(sql, new { Id = id });

                    if (libro == null)
                    {
                        throw new Exception($"Libro con id {id} no encontrado.");
                    }

                    return libro;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al recuperar el Libro de la base de datos.", ex);
                }
            }
        }


        public IEnumerable<Libro> GetAllLibros()
        {
            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var sql = "SELECT ID, Autor, Titulo, Isbn, Estado FROM Libros";
                    var libros = connection.Query<Libro>(sql).ToList();

                    return libros;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los Libros.", ex);
                }
            }
        }


        public bool InsertLibro(LibroDto libroDto)
        {
            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var libro = new Libro
                    {
                        Autor = libroDto.Autor,
                        Titulo = libroDto.Titulo,
                        Isbn = libroDto.Isbn,
                        Estado = true
                    };

                    var sql = @"INSERT INTO Libros (Autor, Titulo, Isbn, Estado) VALUES (@Autor, @Titulo, @Isbn, @Estado)";
                    return connection.Execute(sql, libro) == 1;
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception("No se pudo insertar el Libro en la base de datos.", sqlEx);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error inesperado al insertar el Libro. Por favor chequear.", ex);
                }
            }
        }


        public bool UpdateLibro(Libro libro)
        {
            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var sql = @"UPDATE Libros SET Autor = @Autor, Titulo = @Titulo, Isbn = @Isbn, Estado = @Estado WHERE Id = @Id";

                    return connection.Execute(sql, libro) == 1;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar el Libro. Por favor chequear.", ex);
                }
            }
        }

        public bool DeleteLibro(int libroId)
        {
            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var sql = @"DELETE FROM Libros WHERE Id = @Id";
                    var rowsAffected = connection.Execute(sql, new { Id = libroId });

                    return rowsAffected == 1;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el Libro.", ex);
                }
            }
        }

    }
}
