using CoWork.Domain.Discounts;
using CoWork.Domain.Entities;
using CoWork.Domain.Reservations;
using CoWork.Domain.Spaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Member, Guid> Members { get; }
        IGenericRepository<Space, Guid> Spaces { get; }
        IGenericRepository<WalletAccount, Guid> WalletAccounts { get; }
        IGenericRepository<Discount, Guid> Discounts { get; }
        IGenericRepository<Message, Guid> Messages { get; }
        IGenericRepository<Reservation, Guid> Reservations { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
