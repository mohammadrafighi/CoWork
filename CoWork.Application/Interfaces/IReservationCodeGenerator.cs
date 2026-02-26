using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Interfaces
{
    public interface IReservationCodeGenerator
    {
        Task<string> GenerateAsync(CancellationToken cancellationToken=default);
    }
}
