using CoWork.Application.DTOs.Member;
using CoWork.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly UserManager<IdentityUser<Guid>> _userManager;
        private readonly RSA _rsa;
        public AuthService(UserManager<IdentityUser<Guid>> userManager, RSA rsa)
        {
            _userManager = userManager;
            _rsa = rsa;
        }
        public async Task<Guid> RegisterAsync(RegisterDto registerDto)
        {
            var user = new IdentityUser<Guid>()
            {
                UserName = registerDto.UserName,    
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                foreach(var err in result.Errors)
                {
                Console.WriteLine(err);
                }
               // throw new Exception("We Cant Register Now");
            }
            return user.Id;

        }
        public async Task<string> LoginAsync(LoginDto loginDto)
        {

            var user = await _userManager.FindByNameAsync(loginDto.UserName);
            var Check = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!Check)
            {
                throw new Exception("");
            }
            var signingCredentials = new SigningCredentials(
              new RsaSecurityKey(_rsa),
             SecurityAlgorithms.RsaSha256);
            var claims = new List<Claim>()
            {
          new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
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
                (var user in _userManager.Users.AsNoTracking().ToList())
            {
                var userDto = new UserDto()
                {
                    UserName = user.UserName,
                };
                users.Add(userDto);
            }
            return users;

        }

        public async Task<Guid> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            var user = await _userManager.FindByNameAsync(changePasswordDto.Username);
            var cheak = await _userManager.CheckPasswordAsync(user, changePasswordDto.CurrentPassword);
            if (!cheak)
            {
                throw new Exception();
            }
            var result = await _userManager.ChangePasswordAsync
                (user,
                changePasswordDto.CurrentPassword,
                changePasswordDto.NewPassword);
            if (result.Succeeded)
            { return user.Id; }
            else
            {
                throw new Exception("We cant Change Pass");
            }
        }
        public async Task<Guid> ChangeUserName(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            user.UserName = username;
            await _userManager.UpdateAsync(user);
            return user.Id; 

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
