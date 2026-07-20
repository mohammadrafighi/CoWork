using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Spaces.Command.DeleteSpace
{
    public class DeleteSpaceCommandHandler:ICommandHandler<DeleteSpaceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteSpaceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteSpaceCommand command, CancellationToken cancellationToken)
        {
            var space = await _unitOfWork.Spaces.GetByIdAsync(command.SpaceId, cancellationToken)
                ?? throw new InvalidOperationException("space not found");

            //todo add validations
            _unitOfWork.Spaces.Delete(space);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
