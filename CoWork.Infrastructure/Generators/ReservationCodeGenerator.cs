using CoWork.Application.Interfaces;
using CoWork.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Infrastructure.Generators
{
    public sealed class ReservationCodeGenerator : IReservationCodeGenerator
    {
       
        private readonly Random _random = new();
        private readonly AppDbContext _appDbContext;
        public ReservationCodeGenerator(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<string> GenerateAsync(CancellationToken cancellationToken)
        {
            while (true)
            {
                var code = _random.Next(100000, 999999).ToString();
                var exist = await _appDbContext.Reservations.AnyAsync(r => r.ReservationCode == code, cancellationToken);
                if (!exist) return code;
            }
        }
    }
}
