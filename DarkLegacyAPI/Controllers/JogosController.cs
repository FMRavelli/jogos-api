using Microsoft.AspNetCore.Mvc;
using DarkLegacyAPI.Data;
using DarkLegacyAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DarkLegacyAPI.Controllers
{
    public class JogosController : ControllerBase
    {
        private readonly DarkLegacyContext _context;

        public JogosController(DarkLegacyContext context)
        {
            _context = context;
        }

        // GET: api/Generos
        [HttpGet("Generos")]
        public IActionResult GetGeneros(int page = 1, int pageSize = 10)
        {
            var generos = _context.Generos
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(generos);
        }

        // GET: api/Jogos
        [HttpGet("Jogos")]
        public IActionResult GetJogos(int page = 1, int pageSize = 5)
        {
            var jogos = _context.Jogos.Include(j => j.Genero)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var jogosComGenero = jogos.Select(j => new
            {
                IdJogo = j.IdJogo,
                NmJogo = j.NmJogo,
                DsGenero = j.Genero.DsGenero,
                AnoLancamento = j.AnoLancamento,
                Nota = j.Nota
            }).ToList();

            return Ok(jogosComGenero);
        }


        // POST: api/Generos
        [HttpPost("AddGenero")]
        public IActionResult CreateGenero([FromBody] Generos genero)
        {
            var existingGenero = _context.Generos.FirstOrDefault(g => g.DsGenero == genero.DsGenero);
            if (existingGenero != null)
            {
                return BadRequest("Gênero já cadastrado");
            }

            _context.Generos.Add(genero);
            _context.SaveChanges();

            return Ok($"Gênero criado com sucesso. ID: {genero.IdGenero}");
        }

        // POST: api/Jogos
        [HttpPost("AddJogo")]
        public IActionResult CreateJogos([FromBody] Jogos jogo)
        {
            var existingJogos = _context.Jogos.FirstOrDefault(g => g.NmJogo == jogo.NmJogo);
            if (existingJogos != null)
            {
                return BadRequest("Jogo já cadastrado");
            }

            _context.Jogos.Add(jogo);
            _context.SaveChanges();

            return Ok($"Jogo criado com sucesso. ID: {jogo.IdJogo}");
        }
    }
}
