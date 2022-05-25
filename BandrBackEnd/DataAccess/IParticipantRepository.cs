using BandrBackEnd.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace BandrBackEnd.DataAccess
{
    public interface IParticipantRepository
    {
        public Participant GetParticipantById(int id);
        public void CreateParticipant(Participant participant);
        public void DeleteParticipant(int id);
    }
}
