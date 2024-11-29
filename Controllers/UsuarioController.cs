using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Interfaces.Repository;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IEstudianteService _estudianteService;
        private readonly IProfesorService _profesorService;
        private readonly ILibroService _libroService;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioService usuarioService, IUsuarioRepository usuarioRepository, ILibroService libroService, IEstudianteService estudianteService, IProfesorService profesorService)
        {
            _usuarioService = usuarioService;
            _usuarioRepository = usuarioRepository;
            _estudianteService = estudianteService;
            _profesorService = profesorService;
            _libroService = libroService;
        }

        // GET: api/<EjemploController>
        [HttpGet("all")]
        public ActionResult<List<Usuario>> GetUsuarios()
        {
            //comment
            /*
            List<Usuario> usuarios = _usuarioService.GetAllUsuarios();
            return Ok(usuarios);
            */
            var usuarios = _usuarioRepository.GetAllUsuarios();

            if (usuarios == null || !usuarios.Any())
            {
                return NotFound("No hay usuarios registrados.");
            }

            return Ok(usuarios);
        }

        /*
        // GET: api/<EjemploController>
        [HttpPost("prestar")]
        public ActionResult<List<Libro>> GetLibrosUsuario(Usuario usuario)
        {
            //comment
            return Ok(_usuarioService.GetLibrosUsuario(usuario));
        }*/



        // GET api/<EjemploController>/5
        [HttpGet("{id}")]
        //public ActionResult<User> GetUser(int id)
        public IActionResult GetUsuario(int id)
        {
            // Devuelve un usuario específico por su ID
            Usuario usuario = _usuarioService.FindUsuarioById(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // POST api/<EjemploController>
        [HttpPost("crear")]
        public ActionResult<string> addUsuario([FromBody] Usuario usuario)
        {
            /*var resultado = _usuarioService.SaveUsuario(usuario);

            return Ok(resultado);
            */
            var resultado = _usuarioService.SaveUsuario(usuario);

            if (resultado == "Usuario registrado correctamente.")
            {
                return Ok(resultado);
            }

            return BadRequest(resultado);
        }

        // POST: api/user/prestar
        [HttpPost("prestar{id}")]
        public ActionResult<string> PrestarMaterial([FromBody] Usuario usuario, int libroId)
        {
            var resultadoFinal = ""; 
            var libro = _libroService.FindLibroById(libroId);
            if (libro == null)
            {
                resultadoFinal = "Libro no encontrado.";
            }

            if (usuario is Estudiante estudiante)
            {
                var resultado = _estudianteService.PrestarMaterial(estudiante, libro);
                resultadoFinal = "Libro prestado al estudiante.";
            }
            else if (usuario is Profesor profesor)
            {
                var resultado = _profesorService.PrestarMaterial(profesor, libro);
                resultadoFinal = "Libro prestado al profesor.";
            }

            return resultadoFinal;
        }



        // PUT api/<EjemploController>/5
        [HttpPut("update/{id}")]
        public ActionResult<string> updateUsuario([FromBody] Usuario modUsuario)
        {
            return Ok(_usuarioService.UpdateUsuario(modUsuario));
        }

        // DELETE api/<EjemploController>/5
        [HttpDelete("delete/{id}")]
        public ActionResult<string> DeleteUsuario(int id)
        {
            Usuario usuario = _usuarioService.FindUsuarioById(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(_usuarioService.DeleteUsuario(id));
        }


    }
}
