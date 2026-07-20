using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.Interfaces;
using CoWork.Domain.Spaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Spaces.Command.CreateSpace
{
    public class CreateSpaceCommandHandler:ICommandHandler<CreateSpaceCommand,Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateSpaceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }
        public async Task<Guid>Handle(CreateSpaceCommand command,CancellationToken cancellationToken)
        {
            var space = new Space(command.Name, command.BaseCapacity, command.BasePrice,null);
            await _unitOfWork.Spaces.AddAsync(space,cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return space.Id;

        }
    }
}
