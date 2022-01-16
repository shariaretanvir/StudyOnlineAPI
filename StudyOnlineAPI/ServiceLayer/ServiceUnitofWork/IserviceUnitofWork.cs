using StudyOnlineAPI.ServiceLayer.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyOnlineAPI.ServiceLayer.ServiceUnitofWork
{
    public interface IserviceUnitofWork
    {
        IStudentService StudentService { get; }
    }
}
