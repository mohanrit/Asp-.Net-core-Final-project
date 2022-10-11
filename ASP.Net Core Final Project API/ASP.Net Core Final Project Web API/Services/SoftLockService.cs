using ASP.Net_Core_FinalProject_API.IServices;
using ASP.Net_Core_FinalProject_API.Models;
using ASP.Net_Core_FinalProject_API.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net_Core_FinalProject_API.Services
{
    public class SoftLockService : ISoftLockService
    {
        private readonly ProjectDbContext _dbContext;

        public SoftLockService(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string AddSoftLock(SoftLockModel softLock)
        {
            if (softLock != null)
            {
                _dbContext.Add(new SoftLock
                {
                    EmployeeId = softLock.EmployeeId,
                    Manager = softLock.Requestee,
                    ManagerStatus = softLock.ManagerStatus,
                    RequestDate = softLock.RequestDate,
                    RequestMessage = softLock.RequestMessage,
                });
                _dbContext.SaveChanges();
                return "SoftLock Added successfully";

            }
           
                else
                {
                    return "No Data found";
                }
            
        }

        public Task<List<SoftLockModel>> GetSoftLocks()
        {
            var softlock =  _dbContext.SoftLock.Include(s=>s.Employees).Where(s => s.ManagerStatus == "awaiting_confirmation")
                .Select(s => new SoftLockModel
                {
                    LockId = s.LockId,
                    EmployeeName = s.Employees.Name,
                    EmployeeId = s.EmployeeId,
                    Requestee = s.Manager,
                    ManagerStatus = s.ManagerStatus,
                    RequestMessage = s.RequestMessage,
                    RequestDate = s.RequestDate,
                });

            return Task.FromResult(softlock.ToList());
                                                       
        }

        public string UpdateSoftLockStatus(int id, SoftLockModel softLockDto)
        {
            var softLock = _dbContext.SoftLock.Include(s => s.Employees).FirstOrDefault(s => s.LockId == id);
            if (softLock != null)
            {
                if (softLockDto.ManagerStatus == "approved")
                {
                    softLock.ManagerStatus = softLockDto.ManagerStatus;
                    softLock.Employees.LockStatus = "locked";

                }
                else
                {
                    softLock.ManagerStatus = softLockDto.ManagerStatus;
                    softLock.Employees.LockStatus = "not_requested";
                }
                _dbContext.Update(softLock);
                _dbContext.SaveChanges();

                return "Softlock updated successfully";

            }
            else
            {
                return "Softlock not found";
            }
        }
    }
}
