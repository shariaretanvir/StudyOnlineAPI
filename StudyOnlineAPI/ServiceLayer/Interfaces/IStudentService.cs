using StudyOnlineAPI.Model;
using StudyOnlineRepository.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyOnlineAPI.ServiceLayer.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();
    }
}
