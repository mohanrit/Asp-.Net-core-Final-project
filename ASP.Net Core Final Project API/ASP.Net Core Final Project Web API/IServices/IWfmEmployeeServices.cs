using ASP.Net_Core_FinalProject_API.ViewModel;
using System.Threading.Tasks;

namespace ASP.Net_Core_FinalProject_API.IServices
{
    public interface IWfmEmployeeServices
    {
        Task<List<EmployeeModel>> GetAllEmployees();
        Task<List<EmployeeModel>> UpdateEmployee(EmployeeModel employee);
    }
}
