using Microsoft.AspNetCore.Mvc;
using LMS.Model;
using LMS.Service.Repository;
namespace LMS.API.Controllers
{
    [Route("api/Admin")]
    [ApiController]

    public class AdminController : ControllerBase
    {
        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "admin", "Admin" };
        }
        
        [HttpPost]
        [Route("GetAdminLogin")]
        public IActionResult GetAdminLogin([FromBody] AdminLogin adminLogin)
        {
            IManageAdmin _manageAdmin = new ManageAdmin();
            EventInfo objevent = _manageAdmin.AdminLogin(adminLogin);
            if (objevent == null)
            {
                return NotFound("User not found.");
            }
            if (objevent.Status != true)
            {
                return BadRequest("You can not Admin login.");
            }
            return Ok(objevent);
        }

      
        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
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
    }
}
