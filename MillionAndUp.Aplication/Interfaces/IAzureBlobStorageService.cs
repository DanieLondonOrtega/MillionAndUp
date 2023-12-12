using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MillionAndUp.Aplication.Interfaces
{
    public interface IAzureBlobStorageService
    {
        Task<string> UploadAsync(string fileName, IFormFile file);
        bool ExistFileAsync(string fileName);
        Task DeleteAsync(string fileName);
    }
}
