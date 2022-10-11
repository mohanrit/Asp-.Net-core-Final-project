using ASP.Net_Core_FinalProject_API.ViewModel;

namespace ASP.Net_Core_FinalProject_API.IServices
{
    public interface ISoftLockService
    {
        Task<List<SoftLockModel>> GetSoftLocks();

        string AddSoftLock(SoftLockModel softLock);

        string UpdateSoftLockStatus(int id, SoftLockModel softLock);
    }
}
