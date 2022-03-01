using LMS.Model;

namespace LMS.Service.Repository
{
    public interface IManageAdmin
    {
        EventInfo AdminLogin(AdminLogin adminLogin);
    }
}
