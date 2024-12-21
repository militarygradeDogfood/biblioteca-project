using Biblioteca.Data;
using Biblioteca.Models;

namespace Biblioteca.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _repository;

        public UsuarioService(UsuarioRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<UsuarioDto> GetAllUsuarios()
        {
            IEnumerable<Usuario> usuarios = _repository.GetAllUsuarios();
            return usuarios.Select(usuario => new UsuarioDto
            {
                Nombre = usuario.Nombre,
                Rol = usuario.Rol
            });
        }

        public IEnumerable<UsuarioDto> GetUsuariosByRole(string rol)
        {
            IEnumerable<Usuario> usuarios = _repository.GetUsuariosByRole(rol);
            return usuarios.Select(usuario => new UsuarioDto
            {
                Nombre = usuario.Nombre,
                Rol = usuario.Rol
            });
        }

        public UsuarioDto GetUsuarioById(int id)
        {
            Usuario usuario = _repository.GetUsuarioById(id);
            if (usuario == null) return null;

            return new UsuarioDto
            {
                Nombre = usuario.Nombre,
                Rol = usuario.Rol
            };
        }

        public bool InsertUsuario(Usuario usuario)
        {
            return _repository.InsertUsuario(usuario);
        }

        public bool UpdateUsuario(Usuario usuario)
        {
            return _repository.UpdateUsuario(usuario);
        }

        public bool DeleteUsuario(int usuarioId)
        {
            return _repository.DeleteUsuario(usuarioId);
        }

        public bool PrestarLibro(int usuarioId, int libroId)
        {
            return _repository.PrestarLibro(usuarioId, libroId);
        }

        public bool DevolverLibro(int usuarioId, int libroId)
        {
            return _repository.DevolverLibro(usuarioId, libroId);
        }
    }
}
