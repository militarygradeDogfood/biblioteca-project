using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;
        private readonly IUsuarioService _userService;

        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        // GET: api/<EjemploController>
        [HttpGet]
        public ActionResult<List<Libro>> GetLibro()
        {
            List<Libro> libros = _libroService.GetAllLibros();
            return Ok(libros);
        }


        // GET api/<EjemploController>/5
        [HttpGet("{id}")]
        //public ActionResult<Book> GetLibro(int id)
        public IActionResult GetLibro(int id)
        {
            // Devuelve un usuario específico por su ID
            Libro libro = _libroService.FindLibroById(id);
            if (libro == null)
            {
                return NotFound();
            }

            return Ok(libro);
        }

        // POST api/<EjemploController>
        [HttpPost]
        public ActionResult<string> addLibro([FromBody] Libro libro)
        {
            _libroService.SaveLibro(libro);
            return Ok();
        }

        // PUT api/<EjemploController>/5
        [HttpPut("{id}")]
        public ActionResult<string> updateBook([FromBody] Libro modBook)
        {
            _libroService.UpdateLibro(modBook);
            return Ok(modBook);
        }

        // DELETE api/<EjemploController>/5
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteLibro(int id)
        {
            Libro book = _libroService.FindLibroById(id);
            if (book == null)
            {
                return NotFound();
            }

            _libroService.DeleteLibro(id);
            return Ok();
        }
    }
}
