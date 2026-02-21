using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.DTOs.Member;
using CoWork.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Auth.Query.Login
{
    public class LoginQueryHandler : IQueryHandler<LoginQuery, string>
    {
        private readonly IAuthService _authService;
        public LoginQueryHandler(IAuthService authService)
        {
           _authService = authService;
        }
        public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var loginDto = new LoginDto()
            {
                UserName = request.UserName,
                Password = request.Password,
            };
           var Jwt =  await _authService.LoginAsync(loginDto);
            return Jwt;
        }
    }
}
