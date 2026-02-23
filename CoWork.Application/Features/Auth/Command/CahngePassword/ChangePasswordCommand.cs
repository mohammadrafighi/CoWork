using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.DTOs.Member;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CoWork.Application.Features.Auth.Command.CahngePassword
{
    public record ChangePasswordCommand(string Username , string CurrentPassword , string NewPassword) : ICommand<Guid>
    {
    }
}
