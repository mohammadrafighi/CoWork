using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.DTOs.Member
{
    public class MemberDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalCode { get; set; }
        public bool IsActive { get; set; } 
    }
}
