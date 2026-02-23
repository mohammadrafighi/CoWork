using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Members.Command.ChangeMemberEmail
{
    public class ChangeMemberEmailCommandHandler : ICommandHandler<ChangeMemberEmailCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChangeMemberEmailCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }
        public async Task<bool> Handle(ChangeMemberEmailCommand request, CancellationToken cancellationToken)
        {
            var member = await _unitOfWork.Members.GetByIdAsync(request.memberId,cancellationToken);
            member.ChangeEmail(request.Email);
            return true;
        }
    }
}
