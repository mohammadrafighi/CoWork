using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.DTOs.MinIO
{
    public class FileUploadResultDto
    {
        public string BucketName { get; set; } = null!;
        public string FileName { get; set; } = null!;

    }
}
