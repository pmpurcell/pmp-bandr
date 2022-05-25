using BandrBackEnd.Models;

namespace BandrBackEnd.DataAccess
{
    public interface IInstrumentRepository
    {
        public List<Instrument> getAllInstruments();
        public Instrument getInstrumentById(int id);
    }
}
