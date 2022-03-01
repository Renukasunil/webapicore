using LMS.Model;

namespace LMS.Service.Repository
{
    public class ManageAdmin:IManageAdmin
    {
        public EventInfo AdminLogin(AdminLogin adminLogin)
        {
            EventInfo objevent = new EventInfo();
            adminLogin.UserId = "Admin";
            adminLogin.Password = "Admin@123";
            objevent.Status = true;
            objevent.Message = "Admin login have be succesfully....";
            return objevent;
        }
    }
}