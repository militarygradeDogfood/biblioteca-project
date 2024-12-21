using Biblioteca.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Transactions;

namespace Biblioteca.Data
{
    public class UsuarioRepository
    {
        private readonly DapperContext _context;
        private readonly LibroRepository _repository;

        public UsuarioRepository(DapperContext context, LibroRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var sql = "SELECT Id, Nombre, Rol, LimiteLibros FROM Usuarios";
                    var usuarios = connection.Query<Usuario>(sql).ToList();

                    return usuarios;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los usuarios.", ex);
                }
            }
        }

        public IEnumerable<Usuario> GetUsuariosByRole(String rol)
        {
            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var sql = "SELECT * FROM Usuarios WHERE Rol = @Rol";
                    var usuarios = connection.Query<Usuario>(sql).ToList();

                    return usuarios;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los usuarios. Por favor chequear.", ex);
                }
            }
        }

        public Usuario GetUsuarioById(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var sql = @"SELECT ID, Nombre, Rol, LimiteLibros FROM Usuarios WHERE ID = @Id";
                    var usuario = connection.QueryFirstOrDefault<Usuario>(sql, new { Id = id });

                    if (usuario == null)
                    {
                        throw new Exception($"Usuario con id {id} no encontrado.");
                    }

                    return usuario;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al recuperar el Usuario de la base de datos.", ex);
                }
            }
        }


        public bool InsertUsuario(Usuario usuario)
        {
            using (var connection = _context.CreateConnection())
            {
                try
                {
                    if (usuario.Rol == "Estudiante")
                    {
                        usuario.LimiteLibros = 3;
                    }
                    else if (usuario.Rol == "Profesor")
                    {
                        usuario.LimiteLibros = 5;
                    }
                    else
                    {
                        usuario.LimiteLibros = 0;
                    }

                    var sql = @"INSERT INTO Usuarios (Nombre, Rol, LimiteLibros) 
                        VALUES (@Nombre, @Rol, @LimiteLibros)";

                    return connection.Execute(sql, usuario) == 1;
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception("No se pudo insertar el Usuario en la base de datos.", sqlEx);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error inesperado al insertar el Usuario. Por favor chequear.", ex);
                }
            }
        }


        public bool UpdateUsuario(Usuario usuario)
        {
            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var sql = @"UPDATE Usuarios SET Nombre = @Nombre, Rol = @Rol, LimiteLibros = @LimiteLibros WHERE Id = @Id";

                    return connection.Execute(sql, usuario) == 1;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar el Usuario. Por favor chequear.", ex);
                }
            }
        }

        public bool DeleteUsuario(int usuarioId)
        {
            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var sql = @"DELETE FROM Usuarios WHERE Id = @Id";
                    var rowsAffected = connection.Execute(sql, new { Id = usuarioId });

                    return rowsAffected == 1;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el usuario.", ex);
                }
            }
        }

        public bool PrestarLibro(int usuarioId, int libroId)
        {
            using (var connection = _context.CreateConnection())
            {
                var usuario = GetUsuarioById(usuarioId);
                if (usuario == null)
                {
                    return false;
                }

                var libro = _repository.GetLibroById(libroId);
                if (libro == null || libro.Estado == false)
                {
                    return false;
                }

                int limiteLibros = usuario.Rol == "Estudiante" ? 3 : 5;
                if (usuario.Prestamos.Count >= limiteLibros)
                {
                    return false;
                }

                DateTime fechaDevolucion = usuario.Rol == "Estudiante" ? DateTime.Now.AddDays(7) : DateTime.Now.AddDays(14);

                var prestamo = @"INSERT INTO Prestamos (UsuarioId, LibroId, FechaPrestamo, FechaDevolucion, EstadoPrestamo)
                            VALUES (@UsuarioId, @LibroId, @FechaPrestamo, @FechaDevolucion, @EstadoPrestamo)";

                connection.Execute(prestamo, new
                {
                    UsuarioId = usuarioId,
                    LibroId = libroId,
                    FechaPrestamo = DateTime.Now,
                    FechaDevolucion = fechaDevolucion,
                    EstadoPrestamo = "Prestado"
                });

                var actualizarLibro = @"UPDATE Libros SET Estado = @Estado WHERE Id = @Id";
                connection.Execute(actualizarLibro, new { Estado = false, Id = libroId });

                return true;
            }
        }

        public bool DevolverLibro(int usuarioId, int libroId)
        {
            using (var connection = _context.CreateConnection())
            {
                var prestamo = connection.QueryFirstOrDefault<Prestamo>(
                    "SELECT * FROM Prestamos WHERE UsuarioId = @UsuarioId AND LibroId = @LibroId AND EstadoPrestamo = 'Prestado'",
                    new { UsuarioId = usuarioId, LibroId = libroId }
                );

                if (prestamo == null)
                {
                    return false;
                }

                var actualizarPrestamo = @"UPDATE Prestamos SET EstadoPrestamo = 'Devuelto' WHERE UsuarioId = @UsuarioId AND LibroId = @LibroId";
                connection.Execute(actualizarPrestamo, new { UsuarioId = usuarioId, LibroId = libroId });

                var actualizarLibro = @"UPDATE Libros SET Estado = 1 WHERE Id = @LibroId";
                connection.Execute(actualizarLibro, new { LibroId = libroId });

                return true;
            }
        }

        /*
        Usuario AddUsuario(Usuario usuario);
        Usuario UpdateUsuario(Usuario usuario);
        void DeleteUsuario(int Id);
        */

    }
}
