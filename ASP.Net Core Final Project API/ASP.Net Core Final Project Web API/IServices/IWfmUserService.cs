using ASP.Net_Core_FinalProject_API.ViewModel;

namespace ASP.Net_Core_FinalProject_API.IServices
{
    public interface IWfmUserService
    {
        List<WfmLoginModel> Login(WfmLoginModel login);
    }
}
