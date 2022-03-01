using Microsoft.AspNetCore.Mvc;
using LMS.Model;
using LMS.Service.Repository;

namespace LMS.API.Controllers
{
    [Route("api/Client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IManageUser _manageUser;
        public ClientController(IManageUser manageUser)
        {
            _manageUser = manageUser;

        }
        // GET: api/Client
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Console.WriteLine($"api/client get");
            return new string[] { "value1", "value2" };
        }

        // [HttpGet("{id}", Name = "Get")]
        // public string Get(int id)
        // {
        //     return "value";
        // }

        [HttpGet]
        [Route("verifyOTP")]
        public async Task<IActionResult> verifyOTP(string UserID, string OTP)
        {
            Console.WriteLine(" Verify OTP API Done");
            if (UserID == null && OTP == null)
            {
                return NotFound("OTP not found");
            }
            else
            {
                  Console.WriteLine("Verify Done");
                EventInfo _event = await _manageUser.verifyOTP(UserID, OTP);
                return Ok(_event);
            }
        }

        // // POST: api/Client
        [HttpPost]
        [Route("UserRegistration")]
        public async Task<IActionResult> UserRegistration([FromBody] UserInfo userInfo)
        {
            Console.WriteLine("API UserRegistration");
            EventInfo _eventInfo = await _manageUser.UserRegistration(userInfo);
            if (_eventInfo == null)
            {
                return NotFound("User not found.");
            }
            if (_eventInfo.Status != true)
            {
                return BadRequest(_eventInfo.Message);
            }
            return Ok(_eventInfo);
        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
