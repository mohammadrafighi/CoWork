using AutoMapper;
using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Spaces.Command.UpdateSpaceBase
{
   public class UpdateSpaceBaseCommandHandler:ICommandHandler<UpdateSpaceBaseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateSpaceBaseCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateSpaceBaseCommand command, CancellationToken cancellationToken)
        {
            var space = await _unitOfWork.Spaces.GetByIdAsync(command.SpaceId, cancellationToken)
                ?? throw new InvalidOperationException("space not found");
            
            _mapper.Map(command, space);
            _unitOfWork.Spaces.Update(space);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }
    }
}
