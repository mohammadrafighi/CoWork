using System;
using System.Collections.Generic;
using System.Text;
using CoWork.Domain.Entities;
using CoWork.Domain.Transactions;
using CoWork.Domain.Wallets;
using CoWork.Domain.Reservations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
  

namespace CoWork.Infrastructure.Persistence
{

    public class AppDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Transaction> Transactions {  get; set; }
        public DbSet<WalletAccount> WalletAccounts { get; set; }    
        public DbSet<Reservation> Reservations { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
