using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Interfaces.MinIO
{
    public interface IBucketNameResolver
    {
        string Resolve<TCategory>(); 
    }
}
