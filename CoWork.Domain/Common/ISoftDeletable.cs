using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Common
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
    }
}
