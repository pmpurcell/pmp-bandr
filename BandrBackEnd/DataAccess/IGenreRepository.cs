using BandrBackEnd.Models;

namespace BandrBackEnd.DataAccess
{
    public interface IGenreRepository
    {
        public List<Genre> getAllGenres();
        public Genre getGenreById(int id);
    }
}
