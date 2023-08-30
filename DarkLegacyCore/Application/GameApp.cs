using DarkLegacy.Core.Data.Repositories;
using DarkLegacy.Core.Models;

namespace DarkLegacy.Core.Application
{
    public class GameApp
    {
        private readonly GameRepository _gameRepository;

        public GameApp(GameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public List<Game> GetGames(int page, int pageSize, bool sortScore, bool showDisabled)
        {
            var games = _gameRepository.GetGames(page, pageSize);

            //Como a exclusão de itens é lógica, é possível passar showDisabled para listar todos, incluindo inativos
            if (!showDisabled)
                games = games.Where(w => w.FlEnabled).ToList();

            //Listagem padrão é ordenado crescente pelo Id, se passar sortScore como true, a listagem será decrescente de acordo com a nota
            if (sortScore)
                games = games.OrderByDescending(o => o.Score).ToList();

            return games;
        }

        public Game? GetGame(int idGame)
        {
            var foundGame = _gameRepository.GetGameById(idGame);

            return foundGame;
        }

        public bool GameExists(string nmGame)
        {
            return _gameRepository.GetGameByDescription(nmGame) != null;
        }

        public void CreateGame(Game game)
        {
            game.FlEnabled = true;
            _gameRepository.AddGame(game);
        }

        public Game? UpdateGame(Game newGame)
        {
            var foundGame = _gameRepository.GetGameById(newGame.IdGame);

            if (foundGame == null)
            {
                return null;
            }

            // Aplicar alterações das propriedades do newGame no foundGame
            foundGame.NmGame = newGame.NmGame;
            foundGame.LaunchYear = newGame.LaunchYear;
            foundGame.Score = newGame.Score;
            foundGame.IdGenre = newGame.IdGenre;

            _gameRepository.UpdateGame(foundGame);

            return foundGame;
        }

        public bool RemoveGame(int idGame)
        {
            var foundGame = _gameRepository.GetGameById(idGame);

            if (foundGame == null)
            {
                return false;
            }

            foundGame.FlEnabled = false;

            _gameRepository.UpdateGame(foundGame);

            return true;
        }
    }
}
