

using ASP.Net_Core_FinalProject_API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using ASP.Net_Core_FinalProject_API.IServices;

namespace ASP.Net_Core_FinalProject_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class SoftLockController : ControllerBase
    {
        private readonly ISoftLockService _softLockService;

        public SoftLockController(ISoftLockService softLockService)
        {
            _softLockService = softLockService;
        }

        /// <summary>
        /// Get List of SoftLock
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetSoftLock()
        {
            var softlock = await _softLockService.GetSoftLocks();
            return new OkObjectResult(softlock);
        }

        /// <summary>
        /// Add softlock
        /// </summary>
        /// <param name="softLockModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddSoftLock(SoftLockModel softLockModel)
        {
            try
            {
                var softlock = _softLockService.AddSoftLock(softLockModel);
                return new OkObjectResult(softlock);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Update softlock info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="softLockModel"></param>
        /// <returns></returns>
        [HttpPut, Route("{id}")]
        public ActionResult UpdateSoftLock(int id, SoftLockModel softLockModel)
        {
            try
            {
                var softlock = _softLockService.UpdateSoftLockStatus(id, softLockModel);
                return new OkObjectResult(softlock);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
