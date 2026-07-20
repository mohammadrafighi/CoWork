using CoWork.Domain.Spaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.DTOs.Space
{
    public class SpaceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int BaseCapacity {  get; set; }
        public decimal BaseDailyPrice {  get; set; }
        public WorkHours WorkHours { get; set; }
    }
}
