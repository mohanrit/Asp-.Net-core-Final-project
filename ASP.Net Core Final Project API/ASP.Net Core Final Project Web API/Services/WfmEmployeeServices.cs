using ASP.Net_Core_FinalProject_API.IServices;
using ASP.Net_Core_FinalProject_API.Models;
using ASP.Net_Core_FinalProject_API.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net_Core_FinalProject_API.Services
{
    public class WfmEmployeeServices : IEmployeeService
    {
        private readonly ProjectDbContext _dbContext;
        public WfmEmployeeServices(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<EmployeeModel>> GetAllEmployees()
        {
            var employees = await _dbContext.Employees.Include(s => s.SkillMaps).ThenInclude(s => s.Skills).Where(s=>s.LockStatus == "not_requested").Select(x => new EmployeeModel
            {
                EmployeeID = x.EmployeeID,
                Email = x.Email,
                Name = x.Name,
                Manager = x.Manager,
                Experience = x.Experience,
                Wfm_Manager = x.Wfm_Manager,
                Skills = x.SkillMaps.Select(y => y.Skills.Name).ToList()
            }).ToListAsync();

            return employees;
        }
        public async Task<List<EmployeeModel>> UpdateEmployee(EmployeeModel employee)
        {
            var employees = _dbContext.Employees.FirstOrDefault(s => s.EmployeeID == employee.EmployeeID);
            if (employees != null)
            {
                if (employees.LockStatus == "not_Requested")
                {
                    employees.LockStatus = "request_waiting";
                    

                }
                else
                {
                    employees.LockStatus = employee.LockStatus;
                    
                }
                _dbContext.Update(employees);
                _dbContext.SaveChanges();

                return "Employee updated successfully";

            }
            else
            {
                return "Employee not found";
            }
        }
    }
}
