using System.Data;
using System.Xml.Linq;
using WebApplication1.Interfaces;
using WebApplication1.Interfaces.Repository;
using WebApplication1.Models;
using WebApplication1.Repository;
using static WebApplication1.Models.Libro;
using static WebApplication1.Models.Usuario;

namespace WebApplication1.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        //private readonly UsuarioRepository usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
            //this.usuarioRepository = new UsuarioRepository();

            //Usuario user = new Usuario("nombre", "adm");
            //usuarioRepository.SaveUsuario(user);
        }

        public List<Usuario> GetAllUsuarios()
        {
            //comment
            return usuarioRepository.GetAllUsuarios();
        }

        public string SaveUsuario(Usuario usuario)
        {
            return usuarioRepository.SaveUsuario(usuario);
        }

        public string DeleteUsuario(int id)
        {
            return usuarioRepository.DeleteUsuario(id);
        }

        public void PrestarMaterial() { }
        public void DevolverMaterial() { }

        public string UpdateUsuario(Usuario userMod)
        {
            Usuario user = usuarioRepository.FindUsuarioById(userMod.getId());
            if(user != null)
            {
                user.setRole(userMod.getRol());
                user.setName(userMod.getNombre());
                return "Usuario modificado correctamente.";
            } else
            {
                return "Usuario no encontrado.";
            }
        }

        public List<Libro>? GetLibrosUsuario(Usuario usuario)
        {
            return usuarioRepository.GetLibrosUsuario(usuario);
        }

        public Usuario? FindUsuarioById(int id)
        {
            foreach (var user in usuarioRepository.GetAllUsuarios())
            {
                if (user.getId() == id)
                {
                    return user;
                }
            }

            return null;
        }
    }
}
