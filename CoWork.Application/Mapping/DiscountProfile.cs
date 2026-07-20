using AutoMapper;
using CoWork.Application.DTOs.Discount;
using CoWork.Domain.Discounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Mapping
{
   public class DiscountProfile:Profile
    {
        public DiscountProfile()
        {
            CreateMap<Discount, DiscountDto>();
        }
    }
}
