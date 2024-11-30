using WebApplication1.Interfaces.Repository;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Repository
{
    public class LibroRepository : ILibroRepository
    {
        private LibroService libroService;
        private List<Libro> libros;

        public LibroRepository()
        {
            this.libros = new List<Libro>();

            //ejemplo
            Libro libro = new Libro(1, "autor", "titulo", "asdf1234");
            libros.Add(libro);
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
            if(libros == null)
            {
                return null;
            }

            return libros;
        }

        public string SaveLibro(Libro libro)
        {
            if(libro == null)
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
    }
}
