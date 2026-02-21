using CoWork.Application.DTOs.Member;
using CoWork.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CoWork.Infrastructure.Identity
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RSA _rsa;
        public AuthService(UserManager<IdentityUser> userManager, RSA rsa)
        {
            _userManager = userManager;
            _rsa = rsa;
        }
        public async Task RegisterAsync(RegisterDto registerDto)
        {
            var user = new IdentityUser(registerDto.UserName);
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                throw new Exception("We Cant Register Now");
            }

        }
        public async Task<string> LoginAsync(LoginDto loginDto)
        {

            var user = await _userManager.FindByNameAsync(loginDto.UserName);
            var Check = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            var signingCredentials = new SigningCredentials(
              new RsaSecurityKey(_rsa),
             SecurityAlgorithms.RsaSha256);
            var claims = new List<Claim>()
            {
          new Claim(JwtRegisteredClaimNames.Sub, user.Id),
          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
          };
            var token = new JwtSecurityToken(
            issuer: "Co-WorkAPI",
            audience: "Co-WorkClient",
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: signingCredentials
               );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;


        }
        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = new List<UserDto>();
            foreach
                (var user in _userManager.Users.ToList())
            {
                var userDto = new UserDto()
                {
                    UserName = user.UserName,
                };
                users.Add(userDto);
            }
            return users;

        }

        public async Task ChangePassword(ChangePasswordDto changePasswordDto)
        {
            var user = await _userManager.FindByNameAsync(changePasswordDto.Username);
            var cheak = await _userManager.CheckPasswordAsync(user, changePasswordDto.CurrentPassword);
            if (!cheak)
            {
                throw new Exception();
            }
            await _userManager.ChangePasswordAsync
                (user,
                changePasswordDto.CurrentPassword,
                changePasswordDto.NewPassword);
        }
        //todo:
        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }
        //todo:
        public Task<string> RefreshToken()
        {
            throw new NotImplementedException();
        }

    }
}
