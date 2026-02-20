using CoWork.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Entities
{
    public class Reservation:BaseEntity<Guid>
    {
        public Guid MemberId { get; set; }
        public decimal Amount {  get; set; }
        
    }
}
