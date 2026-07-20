using System;
using System.Collections.Generic;
using System.Text;
using CoWork.Application.Abstraction.CQRS;
using System.Windows.Input;
using ICommand = CoWork.Application.Abstraction.CQRS.ICommand;

namespace CoWork.Application.Features.Discounts.Command.DeleteDiscount
{
    public record DeleteDiscountCommand(Guid DiscountId):ICommand
    {
    }
}
