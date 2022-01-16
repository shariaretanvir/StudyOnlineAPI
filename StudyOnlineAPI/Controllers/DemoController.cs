using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudyOnlineAPI.ServiceLayer.ServiceUnitofWork;
using System;
using System.Threading.Tasks;

namespace StudyOnlineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        public ILogger<DemoController> logger { get; }
        public IserviceUnitofWork ServiceUnitofWork { get; }

        public DemoController(ILogger<DemoController> logger, IserviceUnitofWork serviceUnitofWork)
        {
            this.logger = logger;
            ServiceUnitofWork = serviceUnitofWork;
        }

        [HttpGet,Route("getall")]
        public async Task<IActionResult> getall()
        {
            try
            {
                return Ok(await ServiceUnitofWork.StudentService.GetAllStudents());
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
