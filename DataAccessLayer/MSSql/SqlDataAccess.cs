using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MSSql
{
    public class SqlDataAccess : ISqlDataAccess
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; }

        public SqlDataAccess(IDbConnection connection,IDbTransaction transaction)
        {
            Connection = connection;
            Transaction = transaction;
        }


        public async Task<int> Execute(string sql, Task model)
        {
            try
            {
                return await Connection.ExecuteAsync(sql, model,transaction:Transaction);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<int> ExecuteWithReturnValue(string sql, DynamicParameters param)
        {
            try
            {
                return await Connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure, transaction: Transaction);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<T> Get<T>(string sql, T model)
        {
            try
            {
                return await Connection.QueryFirstOrDefaultAsync<T>(sql, model, transaction:Transaction);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<T>> GetAll<T>(string sql, T model)
        {
            try
            {
                return await Connection.QueryAsync<T>(sql, model, transaction: Transaction);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
