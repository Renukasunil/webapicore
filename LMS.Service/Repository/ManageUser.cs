using LMS.Model;
using LMS.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LMS.Service.Repository
{
    public class ManageUser : IManageUser
    {
        public static List<UserInfo> UserInfos = new List<UserInfo>();
        private readonly AppDbContext _db;
        public ManageUser(AppDbContext db)
        {
            _db = db;
        }

        public List<Country> GetCountries()
        {
            List<Country> lstcountry = new List<Country>();
            Country country = new Country();
            country.CountryId = 1;
            country.CountryName = "India";
            lstcountry.Add(country);
            return lstcountry;
        }
        public List<State> GetStates()
        {
            List<State> lststate = new List<State>();
            State state = new State();
            state.StateId = 1;
            state.StateName = "Uttar Pradesh";
            lststate.Add(state);
            return lststate;
        }
        public List<City> GetCities()
        {
            List<City> lststate = new List<City>();
            City city = new City();
            city.CityId = 1;
            city.CityName = "Noida";
            lststate.Add(city);
            return lststate;
        }
        public async Task<EventInfo> UserRegistration(UserInfo model)
        {
            EventInfo en = new EventInfo();
            try
            {
                if (model != null)
                {
                    await _db.UserInfos.AddAsync(model);
                    await _db.SaveChangesAsync();
                    en.Status = true;
                    if (model.UserID > 0)
                    {
                        await SaveOTP(model);
                        Console.WriteLine("OTP sent Successfully.");
                        en.Message = "You are registered successfully.";
                    }
                    else
                    {
                        return en;
                    }
                }
            }
            catch (Exception)
            {
                en.Status = false;
                en.Message = "Sorry! You are unable to registered.";
                //error in useregistration
                throw;
            }
            return en;
        }
        public string GenerateOTP()
        {
            Random randobj = new Random();
            return randobj.Next(1000, 9999).ToString();
        }
        public async Task<EventInfo> SaveOTP(UserInfo model)
        {
            EventInfo en = new EventInfo();
            Console.WriteLine("user id found: " + model.UserID);
            OTPSend _otp = new OTPSend();
            Console.WriteLine("obj init. ");
            _otp.UserId = model.UserID;
            Console.WriteLine("otp UserId: " + _otp.UserId);
            _otp.OTP = GenerateOTP();
            Console.WriteLine("otp OTP: " + _otp.OTP);
            _otp.MobileNo = model.Mobile;
            Console.WriteLine("otp MobileNo: " + _otp.MobileNo);
            _otp.GenerateTime = DateTime.Now.ToString("yyyy-MM-dd");
            Console.WriteLine("GenerateTime: " + _otp.GenerateTime);
            _otp.IsVerified=true;
            await _db.SaveVerifyOTP.AddAsync(_otp);
            // await _db.SaveVerifyOTP.AddAsync(_otp);
            //await _db.TblSendOTP.AddAsync(_otp);
            await _db.SaveChangesAsync();
            SENDSMS(_otp, _otp.OTP);
            Console.WriteLine(" Send OTP SMS Yoctel Done");
            return en;
        }
        public static string SENDSMS(OTPSend objverify, string Message)
        {
            string _url = "http://newsms.yoctel.com/submitsms.jsp?user=Yoctel1&key=f32240e20cXX&mobile=+91#MOBILE#&message=#MESSAGE#&senderid=OTPYOC&accusage=1";
            string Number = objverify.MobileNo;
            string MessageOTP = "Your OTP Code is - " + Message + "  Thanks OTP";
            string URL = _url.Replace("#MOBILE#", Number).Replace("#MESSAGE#", MessageOTP);
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URL);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                StreamReader sr = new StreamReader(resp.GetResponseStream());
                string results = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return MessageOTP;
        }
        public async Task<EventInfo> verifyOTP(string emailId, string OTP)
        {
            Console.WriteLine("Start function 1. ");
            EventInfo en = new EventInfo();
            var user = await _db.UserInfos.Where(x => x.EmailId == emailId).FirstOrDefaultAsync();
            Console.WriteLine("Start function 2. ");
            if (user == null)
            {
                Console.WriteLine("Start function 3 ");
                en.Status = false;
                en.Message = "Unable to verify otp.";
            }
            else
            {
                Console.WriteLine("Start function 4. ");
                var otpobj = await _db.SaveVerifyOTP.Where(x => x.OTP == OTP && x.UserId == user.UserID && x.IsVerified == false).FirstOrDefaultAsync();
                Console.WriteLine("Start function 5. ");
                if (user != null)
                {
                    Console.WriteLine("obj init. ");
                    //otpobj.IsVerified = true;
                    Console.WriteLine("Start function 6. ");
                    // _db.SaveVerifyOTP.Attach(otpobj);
                    // Console.WriteLine("Start function 7. ");
                    // _db.Entry(otpobj).Property(e => e.IsVerified).IsModified = true;
                    //to save login details
                    Login cllogin = new Login();
                    cllogin.Password = user.Mobile.Substring(0, 6) + "/" + user.Name.Substring(0, 2);
                    Console.WriteLine("otp Password: " + cllogin.Password);
                    cllogin.UserId = emailId;
                    Console.WriteLine("otp UserId: " + user.EmailId);
                    cllogin.IsActive = true;
                    cllogin.IsBlock = false;
                    cllogin.LastLoginTime = DateTime.Now.ToString("yyyy-MM-dd");
                    Console.WriteLine("otp LastLoginTime: " + cllogin.LastLoginTime);
                    cllogin.IsLockOut = true;
                    Console.WriteLine("calling  function 7. ");
                    sendotpconfirmsms(user, cllogin);
                    Console.WriteLine("calling  function 7. ");
                    await _db.ClientLogin.AddAsync(cllogin);
                    await _db.SaveChangesAsync();
                    Console.WriteLine("calling  function 7. ");
                    en.Status = true;
                    en.Message = "otp verified successfully.";
                }
            }
            Console.WriteLine("return: ");
            return en;
        }
        public async Task<EventInfo> UserLogin(Login _login)
        {
            EventInfo en = new EventInfo();
            UserInfo _user = new UserInfo();
            Console.WriteLine("obj init. ");
            _login.UserId = _user.EmailId;
            Console.WriteLine("otp UserId: " + _user.EmailId);
            _login.Password = _user.Mobile.Substring(0, 5) + "/" + _user.Name.Substring(0, 1);
            Console.WriteLine("otp Password: " + _login.Password);
            //sendotpconfirmsms(_user, _login);
            Console.WriteLine(" Send Verify OTP SMS Yoctel Done");
            return en;
        }
        public static string sendotpconfirmsms(UserInfo _userinfo, Login log)
        {
            string org = "Thanks Yoctel!";
            // string Password = _userinfo.Mobile.Substring(0, 5) + "/" + _userinfo.Name.Substring(0, 1);
            string _url = "http://newsms.yoctel.com/submitsms.jsp?user=Yoctel1&key=f32240e20cXX&mobile=+91#MOBILE#&message=#MESSAGE#&senderid=OTPYOC&accusage=1";
            string Number = _userinfo.Mobile;
            Console.WriteLine("Number :!" + Number);
            string MessageOTP = "Your UserName : " + _userinfo.EmailId + " and Pwd: " + log.Password + " for Login with " + org + "";
            string URL = _url.Replace("#MOBILE#", Number).Replace("#MESSAGE#", MessageOTP);

            Console.WriteLine("Message :!" + URL);

            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URL);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                StreamReader sr = new StreamReader(resp.GetResponseStream());
                string results = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message :!" + ex.ToString());
                throw;
            }
            Console.WriteLine("Message :!");
            return MessageOTP;
        }
      
         
        public static string VerifyOTP(UserInfo _userinfo, string Password)
        {
            string org = "Thanks Yoctel";
          // string Password = _userinfo.Mobile.Substring(0, 5) + "/" + _userinfo.Name.Substring(0, 1);
            string _url = "http://newsms.yoctel.com/submitsms.jsp?user=Yoctel1&key=f32240e20cXX&mobile=+91#MOBILE#&message=#MESSAGE#&senderid=OTPYOC&accusage=1";
            string Number = _userinfo.EmailId;
            string MessageOTP = "Your UserName : " + _userinfo.EmailId + " and Pwd: " + Password + " for Login with " + org + "";
            string URL = _url.Replace("#MOBILE#", Number).Replace("#MESSAGE#", MessageOTP);
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URL);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                StreamReader sr = new StreamReader(resp.GetResponseStream());
                string results = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return MessageOTP;
        }
        
    }
}
