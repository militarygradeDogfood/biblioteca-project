using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace WebApplication1.Models
{
    public class Libro
    {
        [Key]
        public int id { get;}
        public string autor { get; set; }

        public string titulo { get; set; }
        public string isbn { get; set; }
        public bool estado { get; set; }

        public Libro(int id, string autor, string titulo, string isbn)
        {
            this.id = id;
            this.autor = autor;
            this.titulo = titulo;
            this.isbn = isbn;
            estado = false;
        }

        public Libro()
        {
        }

        public string getIsbn()
        {
            return isbn;
        }

        public bool getEstado()
        {
            return estado;
        }

        public int getId() { return id; }

        public void setEstado(bool estadoAux) { estado = estadoAux; }

        public string getAutor() { return this.autor; }
        public void setAutor(string autor) { this.autor = autor; }
    
        public string getTitulo() { return titulo; }
        public void setTitulo(string titulo) { this.titulo = titulo; }
    }
}
