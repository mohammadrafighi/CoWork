using CoWork.Application.Interfaces.MinIO;
using CoWork.Application.MarkerType;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Infrastructure.MinIO
{
    public class BucketNameResolver : IBucketNameResolver
    {
        public string Resolve<TCategory>()
        {
            return typeof(TCategory).Name switch
            {
                nameof(ReceiptImage) => "receipt-images",
                _ => throw new InvalidOperationException($"No bucket configured for {typeof(TCategory).Name}")
            };
        }
    }
}
