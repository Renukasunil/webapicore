using System;
using System.ComponentModel.DataAnnotations;

namespace LMS.Model
{
    public class UserInfo
    {
        [Key]
        public long UserID { get; set; }
        [Required (ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Required (ErrorMessage ="Mobile no is required")]
        public string Mobile { get; set; }
        public string EmailId { get; set; }
        public string OrganizationName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pin { get; set; }
        public string TypeOfOrganization { get; set; }
        public string Other { get; set; }
        public string OwnerName { get; set; }
        public string OwnerContactNo { get; set; }
        public string OwnerEmailId { get; set; }
        public string GSTNO { get; set; }
    }
}