using StudyOnlineRepository.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnlineRepository.RepositoryLayer.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentAddressDTO>> GetAllStudents();
    }
}
