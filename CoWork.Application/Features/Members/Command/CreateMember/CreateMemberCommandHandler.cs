using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.DTOs.Member;
using CoWork.Application.Interfaces;
using CoWork.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CoWork.Application.Features.Members.Command.CreateMember
{
    public class CreateMemberCommandHandler : ICommandHandler<CreateMemberCommand,Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;
        public CreateMemberCommandHandler(IUnitOfWork unitOfWork , IAuthService authService)
        {
        _unitOfWork = unitOfWork;   
        _authService = authService; 
        }
        public async Task<Guid> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var registerRequest = new RegisterDto()
            {
                UserName = request.UserName,
                Password = request.passWord,
                
            };
           Guid userId = await _authService.RegisterAsync(registerRequest);
           var member = Member.CreateMember(request.firstName , request.lastName , userId);
           await _unitOfWork.Members.AddAsync(member,cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);  
            return member.Id;

        }
    }
}
