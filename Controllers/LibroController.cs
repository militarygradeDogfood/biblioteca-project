using Biblioteca.Models;
using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly LibroService _libroService;

        public LibroController(LibroService libroService)
        {
            _libroService = libroService;
        }

        // GET: api/Libro
        [HttpGet]
        public IActionResult GetAllLibros()
        {
            var libros = _libroService.GetAllLibros();
            if (libros == null || !libros.Any())
            {
                return NotFound("No se encontraron libros.");
            }

            var libroDtos = libros.Select(libro => new LibroDto
            {
                Autor = libro.Autor,
                Titulo = libro.Titulo,
                Isbn = libro.Isbn
            });

            return Ok(libroDtos);
        }

        // GET: api/Libro/{id}
        [HttpGet("{id}")]
        public IActionResult GetLibroById(int id)
        {
            var libro = _libroService.GetLibroById(id);
            if (libro == null)
            {
                return NotFound("No se encontró el libro con este id.");
            }

            var libroDto = new LibroDto
            {
                Autor = libro.Autor,
                Titulo = libro.Titulo,
                Isbn = libro.Isbn
            };

            return Ok(libroDto);
        }

        // POST: api/Libro
        [HttpPost]
        public IActionResult InsertLibro([FromBody] LibroDto libroDto)
        {
            if (libroDto == null)
            {
                return BadRequest("Los datos del libro son inválidos.");
            }

            var libro = new Libro
            {
                Autor = libroDto.Autor,
                Titulo = libroDto.Titulo,
                Isbn = libroDto.Isbn
            };

            if (_libroService.InsertLibro(libroDto))
            {
                return Ok("Libro creado exitosamente.");
            }

            return BadRequest("Error al crear el libro.");
        }

        // PUT: api/Libro/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateLibro(int id, [FromBody] LibroDto libroDto)
        {
            if (libroDto == null)
            {
                return BadRequest("Los datos del libro son inválidos o el ID no coincide.");
            }

            var libro = new Libro
            {
                Id = id,
                Autor = libroDto.Autor,
                Titulo = libroDto.Titulo,
                Isbn = libroDto.Isbn
            };

            if (_libroService.UpdateLibro(libro))
            {
                return Ok("Libro actualizado exitosamente.");
            }

            return BadRequest("Error al actualizar el libro.");
        }

        // DELETE: api/Libro/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteLibro(int id)
        {
            if (_libroService.DeleteLibro(id))
            {
                return Ok("Libro eliminado exitosamente.");
            }

            return BadRequest("Error al eliminar el libro.");
        }
    }
}
