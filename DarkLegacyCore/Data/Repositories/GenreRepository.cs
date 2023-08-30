using DarkLegacy.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DarkLegacy.Core.Data.Repositories
{
    public class GenreRepository
    {
        private readonly DarkLegacyContext _context;

        public GenreRepository(DarkLegacyContext context)
        {
            _context = context;
        }

        public List<Genre> GetGenres(int page, int pageSize)
        {
            return _context.Genre
                .Where(g => g.FlEnabled)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public Genre? GetGenreById(int idGenre)
        {
            return _context.Genre.FirstOrDefault(g => g.IdGenre == idGenre && g.FlEnabled);
        }

        public Genre? GetGenreByDescription(string dsGenre)
        {
            return _context.Genre.FirstOrDefault(g => g.DsGenre == dsGenre && g.FlEnabled);
        }

        public void AddGenre(Genre genre)
        {
            _context.Genre.Add(genre);
            _context.SaveChanges();
        }

        public void UpdateGenre(Genre genre)
        {
            _context.Entry(genre).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
