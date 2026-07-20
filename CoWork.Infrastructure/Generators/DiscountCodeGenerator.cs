using CoWork.Application.Interfaces;
using CoWork.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Infrastructure.Generators
{
    public sealed class DiscountCodeGenerator:IDiscountCodeGenerator
    {
        private readonly AppDbContext _appDbContext;
        private readonly Random random = new();
        public DiscountCodeGenerator(AppDbContext context)
        {
            _appDbContext = context;
        }
        //todo change
        public async Task<string> CodeGeneratorAsync(CancellationToken cancellationToken)
        {
            while (true)
            {
                var x = random.GetString([], 5);
                var y = random.Next(100000, 999999).ToString();
                var z = x + y;
                var exist = await _appDbContext.Discounts.AnyAsync(d => d.Code == z, cancellationToken);
                if (!exist) return z;
            }
        }
    }
}
