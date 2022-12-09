using System.Collections.Generic;
using System.Linq;
using API_Imcs.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Imcs.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context;

        //Injeção de dependência - balta.io
        public UsuarioController(DataContext context) =>
            _context = context;

        private static List<Usuario> Usuarios = new List<Usuario>();

        // GET: /api/usuario/listar
        [Route("listar")]
        [HttpGet]
        public IActionResult Listar() =>
            Ok(_context.Usuarios.ToList());

        // POST: /api/usuario/cadastrar
        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Usuario Usuario)
        {
            _context.Usuarios.Add(Usuario);
            _context.SaveChanges();
            return Created("", Usuario);
        }

        // GET: /api/usuario/buscar/
        [Route("buscar/{id}")]
        [HttpGet]
        public IActionResult Buscar([FromRoute] int id)
        {
            //Expressão lambda
            Usuario usuario =
                _context.Usuarios.Find(id);
            //IF ternário
            return usuario != null ? Ok(usuario) : NotFound();
        }
    }
}