using CoWork.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Entities
{
    public class Member:BaseEntity<Guid>
    {
        private Member(){}
        private Member(string firstName , string lastName , Guid userId)
        { 
            FirstName = firstName;
            LastName = lastName;
            UserId = userId;
        } 
           
        public string FirstName {  get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string NationalCode {  get; private set; }
        public Guid UserId { get; private set; }
        public bool IsActive { get; private set; } = true;
  
        public void ChangeFirstName(string firstName) => FirstName = firstName;
        public void ChangeLastName(string lastName) => LastName = lastName;
        public void ChangeEmail (string email) => Email = email;    
        public void ChangePhoneNumber(string phoneNumber) => PhoneNumber = phoneNumber; 
        public void ChangeNationalCode(string nationalCode) => NationalCode = nationalCode;
        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;   
        public static Member CreateMember(string firstName, string lastName, Guid userId)
        {
           return new Member(firstName, lastName, userId);
        }

    }
}
