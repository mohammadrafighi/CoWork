using CoWork.Application.DTOs.Member;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Interfaces
{
    public interface IAuthService
    {
        Task<Guid> RegisterAsync(RegisterDto registerDto);
        Task<Guid> ChangeUserName(string UserName);
        Task<string> LoginAsync(LoginDto loginDto);
        Task LogoutAsync();
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<string> RefreshToken();
        Task<Guid> ChangePassword(ChangePasswordDto changePasswordDto);
        

    }
}
