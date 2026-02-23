using CoWork.Application.Interfaces;
using CoWork.Domain.Discounts;
using CoWork.Domain.Entities;
using CoWork.Domain.Reservations;
using CoWork.Domain.Spaces;
using CoWork.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly AppDbContext _context;

        public IGenericRepository<Member, Guid> Members { get; }
        public IGenericRepository<Space, Guid> Spaces { get; }
        public IGenericRepository<WalletAccount, Guid> WalletAccounts { get; }
        public IGenericRepository<Discount, Guid> Discounts { get; }
        public IGenericRepository<Message, Guid> Messages { get; }
        public IGenericRepository<Reservation, Guid> Reservations { get; }

        public UnitOfWork(AppDbContext context)
        {
            //todo:Need to edit
            _context = context;
            Members = new GenericRepository<Member, Guid>(_context);
            Spaces = new GenericRepository<Space, Guid>(_context);
            WalletAccounts = new GenericRepository<WalletAccount, Guid>(_context);
            Discounts = new GenericRepository<Discount, Guid>(_context);
            Messages = new GenericRepository<Message, Guid>(_context);  
            Reservations = new GenericRepository<Reservation, Guid>(_context);  
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
