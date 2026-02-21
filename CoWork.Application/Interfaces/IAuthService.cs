using CoWork.Application.DTOs.Member;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Interfaces
{
    public interface IAuthService
    {
        Task<Guid> RegisterAsync(RegisterDto registerDto);
        Task<string> LoginAsync(LoginDto loginDto);
        Task LogoutAsync();
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<string> RefreshToken();
        Task ChangePassword(ChangePasswordDto changePasswordDto);
        

    }
}
