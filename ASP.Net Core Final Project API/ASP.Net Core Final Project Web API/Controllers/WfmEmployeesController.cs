using ASP.Net_Core_Final_Project_Web_API.IServices;
using ASP.Net_Core_Final_Project_Web_API.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net_Core_FinalProject_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class WfmEmployeesController : ControllerBase
    {
        private readonly IWfmEmployeeServices _employeeService;

        
        public WfmEmployeesController(IWfmEmployeeServices employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Get All Employess Information
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult> Employees()
        {
            try
            {

                var employeeList = await _employeeService.GetAllEmployees();
                return new OkObjectResult(employeeList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPut]

        public async Task<ActionResult> UpdateEmployee(EmployeeModel employee)
        {
            try
            {
                await _employeeService.UpdateEmployee(employee);
                return new OkObjectResult(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
