using Microsoft.Extensions.Logging;
using StudyOnlineAPI.Model;
using StudyOnlineAPI.ServiceLayer.Interfaces;
using StudyOnlineRepository.DTOs;
using StudyOnlineRepository.RepositoryLayer.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyOnlineAPI.ServiceLayer.Classes
{
    public class StudentService : IStudentService
    {
        public IUnitofWork UnitofWork { get; }
        public ILogger<StudentService> logger { get; }

        public StudentService(IUnitofWork unitofWork)
        {
            this.UnitofWork = unitofWork;
            this.logger = new LoggerFactory().CreateLogger<StudentService>();
        }
        public async Task<List<Student>> GetAllStudents()
        {
            try
            {
                IEnumerable<StudentAddressDTO> stdobj = await UnitofWork.StudentRepository.GetAllStudents();
                List<StudentAddressDTO> dTOs = stdobj.ToList();

                var groupbylist = dTOs.GroupBy(t => t.StudentID).Select(t => new { Key = t.Key, stdobj = t });

                List<Student> obj = groupbylist.Select(t => new Student
                {
                    StudentID = t.Key,
                    Name = t.stdobj.Select(x=>x.Name).FirstOrDefault(),
                    IsActive = t.stdobj.Select(x => x.IsActive).FirstOrDefault(),
                    Addresses = t.stdobj.Where(x=>x.AddressStudentID==t.Key).Select(t=>new Address
                    {
                        AddressID = t.AddressID,
                        AddressType = t.AddressType,
                        FullAddress = t.FullAddress,
                        StudentID = t.AddressStudentID
                    }).ToList()
                }).ToList();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
