using DarkLegacy.Core.Data.Repositories;
using DarkLegacy.Core.Models;

namespace DarkLegacy.Core.Application
{
    public class GenreApp
    {

        private readonly GenreRepository _genreRepository;

        public GenreApp(GenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public List<Genre> GetGenres(int page, int pageSize, bool showDisabled)
        {
            var genres = _genreRepository.GetGenres(page, pageSize);

            if (!showDisabled)
            {
                genres = genres.Where(g => g.FlEnabled).ToList();
            }

            return genres;
        }

        public Genre? GetGenre(int idGenre)
        {
            var foundGenre = _genreRepository.GetGenreById(idGenre);

            return foundGenre;
        }

        public bool GenreExists(string dsGenre)
        {
            return _genreRepository.GetGenreByDescription(dsGenre) != null;
        }

        public void CreateGenre(Genre genre)
        {
            _genreRepository.AddGenre(genre);
        }

        public Genre? UpdateGenre(Genre newGenre)
        {
            var foundGenre = _genreRepository.GetGenreById(newGenre.IdGenre);

            if (foundGenre == null)
            {
                return null;
            }

            // Aplicar alterações das propriedades do newGame no foundGame
            foundGenre.DsGenre = newGenre.DsGenre;
            _genreRepository.UpdateGenre(foundGenre);

            return foundGenre;
        }

        public bool RemoveGenre(int idGenre)
        {
            var foundGenre = _genreRepository.GetGenreById(idGenre);

            if (foundGenre == null)
            {
                return false;
            }

            foundGenre.FlEnabled = false;

            _genreRepository.UpdateGenre(foundGenre);

            return true;
        }
    }
}