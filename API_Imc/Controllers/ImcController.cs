using System.Collections.Generic;
using System.Linq;
using API_Imcs.Models;
using API_Imcs.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Imcs.Controllers
{
    [ApiController]
    [Route("api/imc")]
    public class ImcController : ControllerBase
    {
        private readonly DataContext _context;
        public ImcController(DataContext context) =>
            _context = context;


        // POST: /api/imc/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] CalculoImc imc)
        {
            
            imc.Imc = Calculos.CalcularImc
            (imc.Peso, imc.Altura);
            
            imc. ClassificacaoImc = Calculos.ClassificacaoImc(imc.Imc);
            _context.Imcs.Add(imc);
            _context.SaveChanges();
            return Created("", imc);
        }

        // GET: /api/usuario/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            List<CalculoImc> imcs =
                _context.Imcs.Include(u => u.Usuario).ToList();

            if (imcs.Count == 0) return NotFound();

            return Ok(imcs);
            // return imcs.Count != 0 ? Ok(imcs) : NotFound();

        }
        // PATCH: /api/usuario/alterar
        [Route("alterar")]
        [HttpPatch]
        public IActionResult Alterar([FromBody] CalculoImc Id )
        {
            _context.Imcs.Update(Id);
            _context.SaveChanges();
            return Ok(Id);
        }
    }
}