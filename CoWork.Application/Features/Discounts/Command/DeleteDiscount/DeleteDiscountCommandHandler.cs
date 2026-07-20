using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Discounts.Command.DeleteDiscount
{
    public class DeleteDiscountCommandHandler:ICommandHandler<DeleteDiscountCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteDiscountCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteDiscountCommand command,CancellationToken cancellationToken)
        {
            var discount = await _unitOfWork.Discounts.GetByIdAsync(command.DiscountId, cancellationToken)
                ?? throw new InvalidOperationException("discount not found");

            _unitOfWork.Discounts.Delete(discount);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }
    }
}
