using CoWork.Application.DTOs.MinIO;
using CoWork.Application.Interfaces.MinIO;
using Minio;
using Minio.DataModel.Args;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Text;

namespace CoWork.Infrastructure.MinIO
{
    public class MinIORepository : IFileStorageService
    {
        private readonly IMinioClient _minioClient;
        private readonly IBucketNameResolver _bucketResolver;
        public MinIORepository(IMinioClient minioClient , IBucketNameResolver bucketResolver)
        {
            _minioClient = minioClient;
            _bucketResolver = bucketResolver;
        }
        public async Task<FileUploadResultDto> UploadFile<TCategory>(Stream fileStream, string fileName, string contentType,long fileSize, CancellationToken cancellationToken)
        { 
            var bucketName = _bucketResolver.Resolve<TCategory>();

            var bucketExistsArgs = new BucketExistsArgs()
               .WithBucket(bucketName);

            bool found = await _minioClient.BucketExistsAsync(bucketExistsArgs);

            if (!found)
            {
                var makeBucketArgs = new MakeBucketArgs()
                    .WithBucket(bucketName);

                await _minioClient.MakeBucketAsync(makeBucketArgs);
            }
            var stream = fileStream;
            var putArgs = new PutObjectArgs()
                .WithBucket(bucketName)
                .WithObject(fileName)
                .WithStreamData(stream)
                .WithObjectSize(fileSize)
                .WithContentType(contentType);
            await _minioClient.PutObjectAsync(putArgs);
            return new FileUploadResultDto()
            {
                BucketName = bucketName,
                FileName = fileName,
            };
        }

        public async Task<Stream> DownloadFile<TCategory>(string objectName, CancellationToken cancellationToken)
        {
            var bucketName = _bucketResolver.Resolve<TCategory>();
            var memoryStream = new MemoryStream();
            var getArgs = new GetObjectArgs()
                .WithBucket(bucketName)
                .WithObject(objectName)
                .WithCallbackStream(stream =>
                {
                    stream.CopyTo(memoryStream);
                });
            await _minioClient.GetObjectAsync(getArgs);
            memoryStream.Position = 0;
 
            return memoryStream;
        }
        public async Task DeleteAsync<TCategory>(string objectName, CancellationToken cancellationToken)
        {
            var bucketName = _bucketResolver.Resolve<TCategory>();
            var deleteArgs = new RemoveObjectArgs()
                    .WithBucket(bucketName)
                    .WithObject(objectName);

            await _minioClient.RemoveObjectAsync(deleteArgs);
        }

    }
}
