using BandrBackEnd.Models;

namespace BandrBackEnd.DataAccess
{
    public interface IPlayedInstrumentRepository
    {
        public List <PlayedInstrument> getPlayedInstrumentsByUser(int userId);

        public PlayedInstrument getSinglePlayedInstrument(int id);
        public void addPlayedInstrument(PlayedInstrument playedInstrument);
        public void removePlayedInstrument(int id);
    }
}
