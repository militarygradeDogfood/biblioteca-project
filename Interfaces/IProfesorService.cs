using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IProfesorService
    {
        bool AptoPrestar(Profesor p);
        string DevolverMaterial(Profesor profesor, Libro libro);
        string PrestarMaterial(Profesor profesor, Libro libro);
    }
}