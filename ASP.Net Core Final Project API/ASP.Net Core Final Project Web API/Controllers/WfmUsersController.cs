using ASP.Net_Core_FinalProject_API.IServices;
using ASP.Net_Core_FinalProject_API.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net_Core_FinalProject_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WfmUsersController : ControllerBase
    {
        private readonly IWfmUserService _userService;

        public WfmUsersController(IWfmUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpGet("Login")]
        public IActionResult Login([FromQuery] WfmLoginModel model)
        {
            var response = _userService.Login(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }


    }
}
