using CoWork.Domain.Discounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.DTOs.Discount
{
    public class DiscountDto
    {
        public Guid Id { get; set; }
        public string Code {  get; set; }
        public DiscountVisibility Visibility { get; set; }
        public DateTime ExpireAt { get; set; }

    }
}
