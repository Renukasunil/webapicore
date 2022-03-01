using LMS.Model;
namespace LMS.Service.Repository
{
    public interface IManageUser
    {
        List<Country> GetCountries();
        List<State> GetStates();
        List<City> GetCities();
        Task<EventInfo> UserRegistration(UserInfo model);
        Task<EventInfo> verifyOTP(string emailId, string OTP);
        Task<EventInfo> UserLogin(Login _login);
    }
}