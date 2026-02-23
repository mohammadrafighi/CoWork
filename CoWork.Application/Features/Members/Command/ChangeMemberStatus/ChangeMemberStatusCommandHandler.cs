using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Members.Command.ChangeMemberStatus
{
    public class ChangeMemberStatusCommandHandler : ICommandHandler<ChangeMemberStatusCommand,bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChangeMemberStatusCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }
        public async Task<bool> Handle(ChangeMemberStatusCommand request, CancellationToken cancellationToken)
        {
            var members = await _unitOfWork.Members.GetAllAsync(cancellationToken);
            var member = members.FirstOrDefault(x=> x.Id == request.memberId);
            if (member.IsActive == false) { 
            member.Activate();
            }
            else if(member.IsActive == true) 
            {
                member.Deactivate();  
            }
            return member.IsActive;
                
            
        }
    }
}
