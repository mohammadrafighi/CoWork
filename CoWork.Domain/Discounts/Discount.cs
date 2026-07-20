using CoWork.Domain.Common;
using CoWork.Domain.Discounts.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Discounts
{
    public class Discount : AggregateRoot<Guid>
    {
        public string Code { get; private set; }
        public DiscountVisibility Visibility { get; private set; }
        public DateTime ExpireAt { get; private set; }
        /// <summary>
        /// use history of discounts by members
        /// </summary>
        private readonly List<DiscountUsage> _usages = new();
        public IReadOnlyCollection<DiscountUsage> Usages => _usages.AsReadOnly();
        private readonly IDiscountRule _rule;
        private Discount() { }
        public Discount(string code,
            
            DiscountVisibility visibility,
            DateTime expireAt,
            IDiscountRule rule)
        {
            if (string.IsNullOrWhiteSpace(code)) throw new ArgumentException("discount code is required");
            if (expireAt < DateTime.UtcNow) throw new ArgumentException("expire date must be in future");
            Id = Guid.NewGuid();
            Code = code;
            
            Visibility = visibility;
            _rule = rule;
            ExpireAt = expireAt;
        }
        public bool IsExpired() => DateTime.UtcNow > ExpireAt;
        public bool CanBeUsedBy(Guid userId)
        {
            if (IsExpired()) return false;
            if (_usages.Any(x => x.UserId == userId)) return false;
            return true;
        }
        /// <summary>
        /// Calculate discount result before payment
        /// </summary>
        public DiscountResult Apply(Guid userId,decimal totalPrice)
        {
            if (!CanBeUsedBy(userId)) throw new InvalidOperationException("discount can not be used");
            return _rule.Calculate(totalPrice);
        }
        /// <summary>
        /// End of discount After successfull payment
        /// </summary>
        public void MarkAsUsed(Guid userId)
        {
            if (_usages.Any(x => x.UserId == userId)) throw new InvalidOperationException("Discount already used by this user.");

            _usages.Add(new DiscountUsage(userId));
        }
        


    }
}
