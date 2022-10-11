using ASP.Net_Core_FinalProject_API.IServices;
using ASP.Net_Core_FinalProject_API.Models;
using ASP.Net_Core_FinalProject_API.ViewModel;

namespace ASP.Net_Core_FinalProject_API.Services
{
    public class WfmUserService : IUserService
    {
        private readonly ProjectDbContext _dbContext;
   

        public WfmUserService(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;

           
        }
        public  List<WfmLoginModel> Login(WfmLoginModel login)
        {
            List<WfmLoginModel> users =  _dbContext.Users.Where(x => x.UserName == login.UserName && x.Password == login.Password).Select(x => new LoginModel
            {
                UserName = login.UserName,
                Password = login.Password,
            }).ToList();
            return users;
        }
    }
}
