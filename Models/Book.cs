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
    public class Book
    {
        [Key]
        private int id { get; set; }
        public string author { get; set; }

        public string title { get; set; }
        private string isbn { get; set; }
        private bool estado { get; set; }

        public Book(string author, string title, string isbn)
        {
            this.author = author;
            this.title = title;
            this.isbn = isbn;
            estado = false;
            id += id;
        }

        public Book()
        {
            author = "";
            title = "";
            isbn = "";
            id = 0;
        }

        public string getIsbn()
        {
            return isbn;
        }

        public bool getEstado()
        {
            return estado;
        }

        public void setEstado(bool estadoAux) { estado = estadoAux; }
    
        public string getTitle() { return title; }
    }
}
