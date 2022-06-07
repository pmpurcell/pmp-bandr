using BandrBackEnd.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace BandrBackEnd.DataAccess
{
    public interface IMatchRepository
    {
        public Match getMatchByRecId(int recId);
        public void createMatch(Match match);
        public void updateMatch(Match match);
        public void deleteMatch(int id);
        public bool checkMatchExists(int recId, int swiperId);
    }
}
