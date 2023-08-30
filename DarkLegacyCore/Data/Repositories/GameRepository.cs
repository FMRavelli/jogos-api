using DarkLegacy.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DarkLegacy.Core.Data.Repositories
{
    public class GameRepository
    {
        private readonly DarkLegacyContext _context;

        public GameRepository(DarkLegacyContext context)
        {
            _context = context;
        }

        public List<Game> GetGames(int page, int pageSize)
        {
            return _context.Game
                .Where(g => g.FlEnabled)
                .Include(g => g.Genre)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public Game? GetGameById(int idGame)
        {
            return _context.Game.FirstOrDefault(g => g.IdGame == idGame && g.FlEnabled);
        }

        public Game? GetGameByDescription(string nmGame)
        {
            return _context.Game.FirstOrDefault(g => g.NmGame == nmGame && g.FlEnabled);
        }

        public void AddGame(Game game)
        {
            _context.Game.Add(game);
            _context.SaveChanges();
        }

        public void UpdateGame(Game game)
        {
            _context.Entry(game).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}