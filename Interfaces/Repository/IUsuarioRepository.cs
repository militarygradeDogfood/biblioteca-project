using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        List<Usuario>? GetAllUsuarios();
        Usuario? FindUsuarioById(int id);
        string SaveUsuario(Usuario usuario);
        string DeleteUsuario(int id);
        string UpdateUsuario(Usuario usuario);
        List<Libro>? GetLibrosUsuario(Usuario usuario);
        virtual string PrestarMaterial() { return ""; }
        virtual string DevolverMaterial() { return ""; }

    }
}
