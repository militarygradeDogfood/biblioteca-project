using Biblioteca.Data;
using Biblioteca.Models;
using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: api/Usuario
        [HttpGet]
        public IActionResult GetAllUsuarios()
        {
            var usuarios = _usuarioService.GetAllUsuarios();
            if (usuarios == null)
            {
                return NotFound("No se encontraron Usuarios.");
            }

            return Ok(usuarios);
        }

        // GET: api/Usuario/role/{rol}
        [HttpGet("role/{rol}")]
        public IActionResult GetUsuariosByRole(string rol)
        {
            var usuarios = _usuarioService.GetUsuariosByRole(rol);
            if (usuarios == null)
            {
                return NotFound("No se encontraron Usuarios con este Rol.");
            }

            return Ok(usuarios);
        }

        // GET: api/Usuario/{id}
        [HttpGet("{id}")]
        public IActionResult GetUsuarioById(int id)
        {
            var usuario = _usuarioService.GetUsuarioById(id);
            if (usuario == null)
            {
                return NotFound("No hay Usuarios con este id.");
            }

            return Ok(usuario);
        }

        // POST: api/Usuario
        [HttpPost]
        public IActionResult InsertUsuario([FromBody] UsuarioDto usuarioDto)
        {
            if (usuarioDto == null)
            {
                return BadRequest("Los datos del Usuario son inválidos.");
            }

            var usuario = new Usuario
            {
                Nombre = usuarioDto.Nombre,
                Rol = usuarioDto.Rol
            };

            if (_usuarioService.InsertUsuario(usuario))
            {
                return Ok("Usuario creado exitosamente.");
            }

            return BadRequest("Error al crear Usuario.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUsuario(int id, [FromBody] UsuarioDto usuarioDto)
        {
            if (usuarioDto == null)
            {
                return BadRequest("Los datos del usuario son inválidos.");
            }

            var usuario = new Usuario
            {
                Id = id,
                Nombre = usuarioDto.Nombre,
                Rol = usuarioDto.Rol
            };

            if (_usuarioService.UpdateUsuario(usuario))
            {
                return Ok("Usuario actualizado exitosamente.");
            }

            return BadRequest("Error al actualizar el Usuario.");
        }


        // DELETE: api/Usuario/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            if (_usuarioService.DeleteUsuario(id))
            {
                return Ok("Usuario eliminado exitosamente.");
            }

            return BadRequest("Error al eliminar el Usuario.");
        }

        // POST: api/Usuario/prestar/{usuarioId}/{libroId}
        [HttpPost("prestar/{usuarioId}/{libroId}")]
        public IActionResult PrestarLibro(int usuarioId, int libroId)
        {
            var resultado = _usuarioService.PrestarLibro(usuarioId, libroId);
            if (resultado)
            {
                return Ok("Libro prestado exitosamente.");
            }
            return BadRequest("Error al prestar el libro.");
        }

        // POST: api/Devolver/prestar/{usuarioId}/{libroId}
        [HttpPost("devolver/{usuarioId}/{libroId}")]
        public IActionResult DevolverLibro(int usuarioId, int libroId)
        {
            var resultado = _usuarioService.DevolverLibro(usuarioId, libroId);
            if (resultado)
            {
                return Ok("Libro devuelto exitosamente.");
            }
            return BadRequest("Error al devolver el libro.");
        }
    }
}
