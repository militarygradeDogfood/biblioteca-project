using WebApplication1.Interfaces.Repository;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private LibroService libroService;
        private List<Usuario> usuarios;

        public UsuarioRepository()
        {
            //ejemplo
            Usuario user = new Usuario(1, "nombre", "adm");

           this.usuarios = new List<Usuario>();

            usuarios.Add(user);
        }

        public List<Usuario> GetAllUsuarios()
        {
            return usuarios;
        }

        public List<Libro>? GetLibrosPrestados(int id)
        {
            Usuario user = FindUsuarioById(id);
            if (user != null)
            {
                return user.getLibrosPrestados();
            }
            return null;
        }

        public string SaveUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                return "El Usuario está vacío";
            }

            usuarios.Add(usuario);
            return "Usuario registrado correctamente.";
        }

        public Usuario? FindUsuarioById(int id)
        {
            foreach (var user in usuarios)
            {
                if (user.getId() == id)
                {
                    return user;
                }
            }

            return null;
        }

        public string DeleteUsuario(int id)
        {
            Usuario user = FindUsuarioById(id);
            if (user != null)
            {
                usuarios.Remove(user);
                return "Usuario eliminado correctamente.";
            }
            return "El Usuario está vacío";
        }

        public void PrestarMaterial() { }
        public void DevolverMaterial() { }

        public string UpdateUsuario(Usuario usuario)
        {
            Usuario usuarioExistente = FindUsuarioById(usuario.getId());
            if (usuarioExistente != null)
            {
                usuarioExistente.setRole(usuario.getRol());
                usuarioExistente.setName(usuario.getNombre());
                return "Usuario modificado correctamente.";
            }
            else
            {
                return "Usuario no encontrado.";
            }
        }

        public List<Libro>? GetLibrosUsuario(Usuario usuario)
        {
            Usuario usuarioExistente = FindUsuarioById(usuario.getId());
            if (usuarioExistente != null)
            {
                return usuarioExistente.getLibrosPrestados();
            }
            return null;
        }
    }
}

