using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.DTOs.Member
{
    public class ChangePasswordDto
    {
        public string Username {  get; set; }
        public string CurrentPassword { get; set; }    
        public string NewPassword { get; set; }

    }
}
