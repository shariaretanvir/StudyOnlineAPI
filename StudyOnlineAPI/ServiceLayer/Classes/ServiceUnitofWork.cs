using Microsoft.Extensions.Logging;
using StudyOnlineAPI.ServiceLayer.Interfaces;
using StudyOnlineAPI.ServiceLayer.ServiceUnitofWork;
using StudyOnlineRepository.RepositoryLayer.UnitofWork;

namespace StudyOnlineAPI.ServiceLayer.Classes
{
    public class ServiceUnitofWork : IserviceUnitofWork
    {
        private readonly ILogger<ServiceUnitofWork> logger;
        public IUnitofWork UnitofWork { get; }
        private IStudentService studentService;
        public ServiceUnitofWork(IUnitofWork unitofWork,ILogger<ServiceUnitofWork> logger)
        {
            UnitofWork = unitofWork;
            this.logger = logger;
        }
        public IStudentService StudentService
        {
            get
            {
                return studentService?? (studentService = new StudentService(UnitofWork));
            }
        }
    }
}
