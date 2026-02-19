using CoWork.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Entities
{
    public class Space:BaseEntity<Guid>
    {
        public int Capacity {  get; set; }
        public TimeOnly StartTime {  get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal Price {  get; set; }
        public bool IsActive { get; set; }
    }
}
