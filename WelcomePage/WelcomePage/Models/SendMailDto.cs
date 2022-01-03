using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WelcomePage.Models
{
    public class SendMailDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string ContactNo { get; set; }
        public string Message { get; set; } 
       
    }
}
