using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MillionAndUp.Aplication.Interfaces
{
    /// <summary>
    /// Interface to implement in the azure blob storage service
    /// </summary>
    public interface IAzureBlobStorageService
    {
        Task<string> UploadAsync(string fileName, IFormFile file);
        bool ExistFileAsync(string fileName);
        Task DeleteAsync(string fileName);
    }
}
