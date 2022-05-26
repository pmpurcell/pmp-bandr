using BandrBackEnd.Models;

namespace BandrBackEnd.DataAccess
{
    public interface IPlayedGenreRepository
    {
        public List<PlayedGenre> getPlayedGenresByUser(int userId);
        public PlayedGenre getSinglePlayedGenre(int id);
        public void addPlayedGenre(PlayedGenre playedGenre);
        public void removePlayedGenre(int id);
    }
}
