using CoWork.Application.DTOs.MinIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Interfaces.MinIO
{
    public interface IFileStorageService
    {
        Task<FileUploadResultDto> UploadFile<TCategory>(
        Stream fileStream,
        string fileName,
        string contentType,
        long fileSize,
        CancellationToken cancellationToken);

        Task<Stream> DownloadFile<TCategory>(
        string objectName,
        CancellationToken cancellationToken);

        Task DeleteAsync<TCategory>(
            string objectName,
            CancellationToken cancellationToken);

    }
}
