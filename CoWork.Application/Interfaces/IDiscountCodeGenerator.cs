using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Interfaces
{
    public interface IDiscountCodeGenerator
    {
        Task<string>CodeGeneratorAsync(CancellationToken cancellationToken=default);
    }
}
