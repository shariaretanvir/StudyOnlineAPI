using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnlineRepository.RepositoryLayer.Classes
{
    public class BaseRepository
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; }
        public BaseRepository(IDbConnection connection, IDbTransaction transaction)
        {
            Connection = connection;
            Transaction = transaction;
        }
    }
}
