using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IEstudianteService
    {
        bool AptoPrestar(Estudiante e);
        string DevolverMaterial(Estudiante estudiante, Libro libro);
        string PrestarMaterial(Estudiante estudiante, Libro libro);
    }
}