using DataAccessLayer.MSSql;
using StudyOnlineRepository.DTOs;
using StudyOnlineRepository.RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnlineRepository.RepositoryLayer.Classes
{
    public class StudentRepository : BaseRepository,IStudentRepository
    {
        private readonly ISqlDataAccess sqlDataAccess;
        public StudentRepository(IDbConnection connection,IDbTransaction transaction) : base(connection,transaction)
        {
            sqlDataAccess = new SqlDataAccess(Connection,transaction);
        }
        public async Task<IEnumerable<StudentAddressDTO>> GetAllStudents()
        {
            try
            {
                return await sqlDataAccess.GetAll("LstStudents", new StudentAddressDTO { });                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
