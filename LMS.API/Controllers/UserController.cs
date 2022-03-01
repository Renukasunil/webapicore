using Microsoft.AspNetCore.Mvc;
using LMS.Model;
using LMS.Service.Repository;
namespace LMS.API.Controllers
{
    [Route("api/User")]
    [ApiController]

    public class UserController : ControllerBase
    {private readonly IManageUser _manageUser;
        public UserController(IManageUser manageUser)
         {
           _manageUser=manageUser;

         }
        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Console.WriteLine($"api/user get");
            return new string[] { "value1", "value2" };
        }
        
       
        // [HttpGet("{id}", Name = "Get")]
        // public string Get(int id)
        // {
        //     return "value";
        // }

        // // POST: api/User
        [HttpPost]
        public void Post([FromBody] UserInfo userInfo)
        {
            
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }



        // TODO : All resource should be seperate API, i.e. seperate controller
        [HttpGet]
        [Route("GetCountry")]
        public JsonResult GetCountry()
        {
           
            List<Country> lstcountry = _manageUser.GetCountries();
            return new JsonResult(lstcountry);
        }

        [HttpGet]
        [Route("GetState")]
        public JsonResult GetState()
        {
            List<State> lststate = _manageUser.GetStates();
            return new JsonResult(lststate);
        }

        [HttpGet]
        [Route("GetCity")]
        public JsonResult GetCity()
        {         
            List<City> lstcity = _manageUser.GetCities();
            return new JsonResult(lstcity);
        }
        
        /// TODO : @Pooja WOrk on this
        [HttpPost]
        [Route("UserLogin")]
        public async Task<IActionResult> UserLogin([FromBody] Login login)
        {
            Console.WriteLine("API UserLogin");
            EventInfo objevent = await _manageUser.UserLogin(login);
            if (objevent == null)
            {
                return NotFound("User not found.");
            }
            if (objevent.Status != true)
             {
                return BadRequest("You can not login.");
             }
            return Ok(objevent);
        }
    }
}
