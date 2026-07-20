using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.Interfaces;
using CoWork.Domain.Discounts;
using CoWork.Domain.Discounts.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Discounts.Command.CreateDiscount
{
    public class CreateDiscountCommandHandler:ICommandHandler<CreateDiscountCommand,Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDiscountCodeGenerator _generator;
        private readonly IDiscountRule rule;
        public CreateDiscountCommandHandler(IUnitOfWork unitOfWork,IDiscountCodeGenerator generator,IDiscountRule discountRule)
        {
            _unitOfWork = unitOfWork;
            _generator = generator;
            rule = discountRule;
        }
        public async Task<Guid>Handle(CreateDiscountCommand command,CancellationToken cancellationToken)
        {
            var discountCode=await _generator.CodeGeneratorAsync(cancellationToken);
            var discount = new Discount(discountCode, command.Visibility, command.ExpireAt, rule);
            await _unitOfWork.Discounts.AddAsync(discount,cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return discount.Id;


        }
    }
}
