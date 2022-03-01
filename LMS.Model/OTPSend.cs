using System;
using System.ComponentModel.DataAnnotations;

namespace LMS.Model
{
    public class OTPSend
    {
        [Key]
        public long VId { get; set; }
        public long UserId { get; set; }
        public string OTP { get; set; }
        public string MobileNo { get; set; }
        public string GenerateTime { get; set; }
        public bool IsVerified {get;set;}
      
    }
}