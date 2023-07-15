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
        public IActionResult GetGeneros(int page = 1, int pageSize = 5, bool mostrarInativos = false)
        {

            //Realiza paginação e monta a lista para exibição
            var generos = _context.Generos
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();


            //Como a exclusão de itens é lógica, é possível passar mostrarInativos para listar todos, incluindo inativos
            if (!mostrarInativos)
                generos = generos.Where(w => w.FlAtivo).ToList();

            return Ok(generos);
        }

        // GET: api/Jogos
        [HttpGet("Jogos")]
        public IActionResult GetJogos(int page = 1, int pageSize = 5, bool ordenarNota = false, bool mostrarInativos = false)
        {
            var jogosQuery = _context.Jogos.Include(j => j.Genero);

            //Realiza paginação e monta a lista para exibição
            var jogos = jogosQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            //Como a exclusão de itens é lógica, é possível passar mostrarInativos para listar todos, incluindo inativos
            if (!mostrarInativos)
                jogos = jogos.Where(w => w.FlAtivo).ToList();

            //Listagem padrão é ordenado crescente pelo Id, se passar ordenarNota como true, a listagem será decrescente de acordo com a nota
            if (ordenarNota)
                jogos = jogos.OrderByDescending(o => o.Nota).ToList();

            //Mapeia Jogos com Generos usando ViewModel
            var jogosComGenero = jogos.Select(s => s.MapToViewModel()).ToList();

            return Ok(jogosComGenero);
        }

        // GET: api/Generos
        [HttpGet("Generos/{idGenero}")]
        public IActionResult ConsultaGenero(int idGenero)
        {
            //Valida se existe
            var generoencontrado = _context.Generos.FirstOrDefault(f => f.IdGenero == idGenero);

            if (generoencontrado == null)
                return NotFound("Gênero não encontrado!");

            return Ok(generoencontrado);
        }

        // GET: api/Jogos
        [HttpGet("Jogos/{idJogo}")]
        public IActionResult ConsultaJogo(int idJogo)
        {
            //Valida se existe
            var jogoencontrado = _context.Jogos.Include(j => j.Genero).FirstOrDefault(f => f.IdJogo == idJogo);

            if (jogoencontrado == null)
                return NotFound("Jogo não encontrado!");

            return Ok(jogoencontrado.MapToViewModel());
        }


        // POST: api/Generos
        [HttpPost("Generos")]
        public IActionResult CreateGenero([FromBody] Generos genero)
        {
            //Valida para, se existir, não cadastra duplicado
            var existingGenero = _context.Generos.FirstOrDefault(f => f.DsGenero == genero.DsGenero);

            if (existingGenero != null)
            {
                return BadRequest("Gênero já cadastrado");
            }

            _context.Generos.Add(genero);
            _context.SaveChanges();

            return Created($"/BuscaGeneros?idGenero={genero.IdGenero}", genero);
        }

        // POST: api/Jogos
        [HttpPost("Jogos")]
        public IActionResult CreateJogos([FromBody] Jogos jogo)
        {
            //Valida para, se existir, não cadastra duplicado
            var existingJogos = _context.Jogos.FirstOrDefault(g => g.NmJogo == jogo.NmJogo);

            if (existingJogos != null)
            {
                return BadRequest("Jogo já cadastrado");
            }

            _context.Jogos.Add(jogo);
            _context.SaveChanges();

            return Created($"/BuscaJogos?idJogo={jogo.IdJogo}", jogo);
        }

        // PUT: api/Jogos
        [HttpPut("Jogos")]
        public async Task <IActionResult> UpdateJogos([FromBody] Jogos jogo, bool ativar = false)
        {
            //Procura no banco se existe de modo assíncrono
            var jogoExistente = await _context.Jogos.FindAsync(jogo.IdJogo);

            if (jogoExistente == null)
            {
                return NotFound("Jogo não encontrado");
            }

            //Se ativar for true, o FlAtivo do item será 1 independente do status original, se ativar for false, irá manter o antigo
            if (ativar)
                jogo.FlAtivo = true;
            else
                jogo.FlAtivo = jogoExistente.FlAtivo;

            _context.Entry(jogoExistente).CurrentValues.SetValues(jogo);

            await _context.SaveChangesAsync();

            return Ok($"Jogo atualizado com sucesso. ID: {jogo.IdJogo}");
        }

        // PUT: api/Generos
        [HttpPut("Generos")]
        public async Task<IActionResult> UpdateGeneros([FromBody] Generos genero, bool ativar = false)
        {
            //Procura no banco se existe de modo assíncrono
            var generoExistente = await _context.Generos.FindAsync(genero.IdGenero);

            if (generoExistente == null)
            {
                return NotFound("Jogo não encontrado"); // Jogo não encontrado
            }

            //Se ativar for true, o FlAtivo do item será 1 independente do status original, se ativar for false, irá manter o antigo
            if (ativar)
                genero.FlAtivo = true;
            else
                genero.FlAtivo = generoExistente.FlAtivo;

            _context.Entry(generoExistente).CurrentValues.SetValues(genero);

            await _context.SaveChangesAsync();

            return Ok($"Jogo atualizado com sucesso. ID: {genero.IdGenero}");
        }


        // DELETE: api/Jogos
        [HttpDelete("Jogos")]
        public IActionResult RemoveJogos(int idJogo)
        {
            //Procura o item de acordo com o Id
            var jogoEncontrado = _context.Jogos.FirstOrDefault(f => f.IdJogo == idJogo);

            if (jogoEncontrado == null)
            {
                return NotFound("Jogo não encontrado");
            }

            //Seta o item, caso encontrado, como DESATIVADO
            jogoEncontrado.FlAtivo = false;
            _context.Jogos.Update(jogoEncontrado);
            _context.SaveChanges();

            return Ok($"Jogo {jogoEncontrado.NmJogo} deletado com sucesso.");
        }


        // DELETE: api/Generos
        [HttpDelete("Generos")]
        public IActionResult RemoveGeneros(int idGenero)
        {
            //Procura o item de acordo com o Id
            var generoEncontrado = _context.Generos.FirstOrDefault(f => f.IdGenero == idGenero);

            if (generoEncontrado == null)
            {
                return NotFound("Jogo não encontrado");
            }

            //Seta o item, caso encontrado, como DESATIVADO
            generoEncontrado.FlAtivo = false;
            _context.Generos.Update(generoEncontrado);
            _context.SaveChanges();

            return Ok($"Gênero {generoEncontrado.DsGenero} deletado com sucesso.");
        }

    }
}
