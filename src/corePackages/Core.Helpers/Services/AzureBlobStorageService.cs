using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;

namespace Core.Helpers.Services
{
    public class AzureBlobStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName;

        public AzureBlobStorageService(string connectionString, string containerName)
        {
            _blobServiceClient = new BlobServiceClient(connectionString);
            _containerName = containerName;
        }

        private BlobContainerClient GetContainerClient()
        {
            return _blobServiceClient.GetBlobContainerClient(_containerName);
        }

        public async Task UploadFileAsync(string blobName, IFormFile formFile, bool overwrite = true)
        {
            BlobClient blobClient = GetContainerClient().GetBlobClient(blobName);
            using (var stream = formFile.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, overwrite);
            }
        }

        public async Task MoveFileAsync(string sourceBlobName, string destinationBlobName)
        {
            var containerClient = GetContainerClient();
            BlobClient sourceBlobClient = containerClient.GetBlobClient(sourceBlobName);
            BlobClient destinationBlobClient = containerClient.GetBlobClient(destinationBlobName);


            await destinationBlobClient.StartCopyFromUriAsync(sourceBlobClient.Uri);
            await sourceBlobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
        }

        public async Task UpdateFileAsync(string blobName, IFormFile formFile)
        {
            BlobClient blobClient = GetContainerClient().GetBlobClient(blobName);
            using (var stream = formFile.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, overwrite: true);
            }
        }

        public async Task DeleteFileAsync(string blobName)
        {
            BlobClient blobClient = GetContainerClient().GetBlobClient(blobName);
            await blobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
        }
    }
}
