using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Members.Command.UpdateMemberProfile
{
    public class UpdateMemberCommandHandler : ICommandHandler<UpdateMemberProfileCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService; 
        public UpdateMemberCommandHandler(IUnitOfWork unitOfWork,IAuthService authService)
        {
            _unitOfWork = unitOfWork;   
            _authService = authService;     
        }
        public async Task<Guid> Handle(UpdateMemberProfileCommand request, CancellationToken cancellationToken)
        {
            var userId = await _authService.ChangeUserName(request.UserName);
            var Member = await _unitOfWork.Members.GetByIdAsync(request.MemberId,cancellationToken);
            Member.ChangeFirstName(request.FirstName);
            Member.ChangeLastName(request.LastName);    
            Member.ChangeNationalCode(request.NationalCode);
            return Member.Id;

            
        }
    }
}
