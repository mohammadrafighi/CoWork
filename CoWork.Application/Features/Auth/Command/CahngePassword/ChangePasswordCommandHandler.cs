using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.DTOs.Member;
using CoWork.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Auth.Command.CahngePassword
{
    public class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand,Guid>
    {
        private readonly IAuthService _authService;
        public ChangePasswordCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<Guid> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var changepassworddto = new ChangePasswordDto()
            {
                Username = request.Username,
                CurrentPassword = request.CurrentPassword,
                NewPassword = request.NewPassword,
            };
           var userId =  await _authService.ChangePassword(changepassworddto);
            return userId;
        }
    }
}
