using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WebApplication1.Models.Libro;

namespace WebApplication1.Models
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        protected List<Libro> librosPrestados { get; set; }
        public string rol { get; set; }


        public Usuario(int id, string nombre, string rol)
        {
            this.id = id;
            this.nombre = nombre;
            this.rol = rol;
            this.librosPrestados = new List<Libro>();
        }

        public Usuario()
        {
        }

        public int getId()
        {
            return this.id;
        }

        public string getNombre() { return this.nombre; }

        public void setName(string nombre)
        {
            this.nombre = nombre;
        }

        public void setRole(string rol)
        {
            this.rol = rol;
        }

        public string getRol()
        {
            return rol;
        }

        public List<Libro> getLibrosPrestados()
        {
            return librosPrestados;
        }
    }
}
