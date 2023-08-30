using Microsoft.AspNetCore.Mvc;
using DarkLegacy.Core.Application;
using DarkLegacy.Core.Models;
using DarkLegacy.API.ViewModel;
using Mapster;

namespace DarkLegacy.API.Controllers
{
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly GameApp _gameApp;

        public GameController(GameApp gameapp)
        {
            _gameApp = gameapp;
        }

        // GET: api/Games
        [HttpGet]
        public IActionResult GetGames(int page = 1, int pageSize = 5, bool sortScore = false, bool showDisabled = false)
        {
            var gamesGenre = _gameApp.GetGames(page, pageSize, sortScore, showDisabled);

            var response = gamesGenre.Adapt<List<GameViewModel>>();

            return Ok(response);
        }

        // GET: api/Games
        [HttpGet("{idGame}")]
        public IActionResult GetGame(int idGame)
        {
            var foundGame = _gameApp.GetGame(idGame);

            if (foundGame == null)
                return NotFound();

            var response = foundGame.Adapt<GameViewModel>();

            return Ok(response);
        }

        // POST: api/Games
        [HttpPost]
        public IActionResult CreateGames([FromBody] Game game)
        {
            if (_gameApp.GameExists(game.NmGame))
            {
                return BadRequest("Jogo já cadastrado");
            }

            _gameApp.CreateGame(game);

            return Created($"/GetGenre?idGenre={game.IdGame}", game);
        }

        // PUT: api/Games
        [HttpPut]
        public IActionResult UpdateGames([FromBody] Game game)
        {
            var result = _gameApp.UpdateGame(game);

            if (result == null)
                return NotFound();

            var response = result.Adapt<GameViewModel>();

            return Ok(response);
        }

        // DELETE: api/Games
        [HttpDelete]
        public IActionResult RemoveGames(int idgame)
        {
            var result = _gameApp.RemoveGame(idgame);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}