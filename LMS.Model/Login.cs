using System;
using System.ComponentModel.DataAnnotations;

namespace LMS.Model
{
    public class Login
    {
        [Key]
        public long LoginId { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsBlock { get; set; }
        public bool RememberMe { get; set; }
        public string LastLoginTime { get; set; }
        public string IPAddress { get; set; }
        public bool IsLockOut { get; set; }
    }
}