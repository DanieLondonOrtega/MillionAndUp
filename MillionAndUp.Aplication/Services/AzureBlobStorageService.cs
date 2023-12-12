using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MillionAndUp.Aplication.Interfaces;

namespace MillionAndUp.Aplication.Services
{
    public class AzureBlobStorageService : IAzureBlobStorageService
    {
        private readonly IConfiguration _configuration;
        private readonly string azureStorageConnectionString;
        public AzureBlobStorageService(IConfiguration configuration)
        {
            _configuration = configuration;
            this.azureStorageConnectionString = _configuration.GetSection("AzureBlobStorageConnection").Value;
        }
        public async Task DeleteAsync(string fileName)
        {
            var blobContainerClient = new BlobContainerClient(this.azureStorageConnectionString, Constants.Constants.AzureBlobStorageContainer);
            var blobClient = blobContainerClient.GetBlobClient(fileName);
            if (blobClient != null)
            {
                await blobClient.DeleteAsync(); 
            }
        }

        public bool ExistFileAsync(string fileName)
        {
            var blobContainerClient = new BlobContainerClient(this.azureStorageConnectionString, Constants.Constants.AzureBlobStorageContainer);
            return blobContainerClient.GetBlobClient(fileName).Exists();
        }

        public async Task<string> UploadAsync(string fileName, IFormFile file)
        {
            var blobContainerClient = new BlobContainerClient(this.azureStorageConnectionString, Constants.Constants.AzureBlobStorageContainer);
            var blobHttpHeader = new BlobHttpHeaders { ContentType = file.ContentType };
            var blobClient = blobContainerClient.GetBlobClient(fileName);
            await using (Stream stream = file.OpenReadStream())
            {
                // Upload the file async
                var prueba = await blobClient.UploadAsync(stream, new BlobUploadOptions { HttpHeaders = blobHttpHeader });
            }          
            return blobClient.Uri.ToString();
        }
    }
}
