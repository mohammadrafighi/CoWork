using CoWork.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Entities
{
    public class Member:BaseEntity<Guid>
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }   
        public string PhoneNumber { get; set;}
        public string NationalCode {  get; set; }
        public User User { get; set; } = null!;
  

    }
}
