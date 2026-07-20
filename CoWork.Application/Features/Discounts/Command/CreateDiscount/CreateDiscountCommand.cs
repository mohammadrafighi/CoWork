using CoWork.Application.Abstraction.CQRS;
using CoWork.Domain.Discounts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CoWork.Application.Features.Discounts.Command.CreateDiscount
{
     public record CreateDiscountCommand(DiscountVisibility Visibility,DateTime ExpireAt):ICommand<Guid>
    {

    }
}
