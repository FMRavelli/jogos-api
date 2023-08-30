using Microsoft.AspNetCore.Mvc;
using DarkLegacy.Core.Application;
using DarkLegacy.Core.Models;
using Mapster;
using DarkLegacy.API.ViewModel;

namespace DarkLegacy.API.Controllers
{
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly GenreApp _genreApp;

        public GenreController(GenreApp genreapp)
        {
            _genreApp = genreapp;
        }

        // GET: api/Genres
        [HttpGet]
        public IActionResult GetGenres(int page = 1, int pageSize = 5, bool showDisabled = false)
        {
            //Realiza paginação e monta a lista para exibição
            var genres = _genreApp.GetGenres(page, pageSize, showDisabled);

            return Ok(genres.Adapt<List<GenreViewModel>>());
        }

        // GET: api/Genres
        [HttpGet("{idGenre}")]
        public IActionResult GetGenre(int idGenre)
        {
            var foundGenre = _genreApp.GetGenre(idGenre);

            if (foundGenre == null)
                return NotFound();

            return Ok(foundGenre.Adapt<GenreViewModel>());
        }

        // POST: api/Genres
        [HttpPost]
        public IActionResult CreateGenre([FromBody] Genre genre)
        {
            if (_genreApp.GenreExists(genre.DsGenre))
            {
                return BadRequest("Gênero já cadastrado");
            }

            _genreApp.CreateGenre(genre);

            return Created($"/GetGenre?idGenre={genre.IdGenre}", genre);
        }

        // PUT: api/Genres
        [HttpPut]
        public IActionResult UpdateGenres([FromBody] Genre genre)
        {
            var result = _genreApp.UpdateGenre(genre);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // DELETE: api/Genres
        [HttpDelete]
        public IActionResult RemoveGenres(int idGenre)
        {
            var result = _genreApp.RemoveGenre(idGenre);

            if (!result)
                return NotFound();

            return NoContent();
        }

    }
}