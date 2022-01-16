using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MSSql
{
    public interface ISqlDataAccess
    {
        Task<int> Execute(string sql,Task model);
        Task<int> ExecuteWithReturnValue(string sql, DynamicParameters param);
        Task<IEnumerable<T>> GetAll<T>(string sql, T model);
        Task<T> Get<T>(string sql, T model);
    }
}
