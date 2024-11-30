using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IUsuarioService
    {

        List<Usuario>? GetAllUsuarios();
        Usuario? FindUsuarioById(int id);
        string SaveUsuario(Usuario usuario);
        string DeleteUsuario(int id);
        string UpdateUsuario(Usuario usuario);
        List<Libro>? GetLibrosUsuario(Usuario usuario);
        virtual string PrestarMaterial() { return ""; }
        virtual string DevolverMaterial() { return ""; }
        /*
        List<Usuario>? GetAllUsuarios();
        Usuario? FindUsuarioById(int id);
        string SaveUsuario(Usuario usuario);
        string DeleteUsuario(int id);
        string UpdateUsuario(Usuario usuario);
        List<Libro>? GetLibrosUsuario(Usuario usuario);*/
    }
}