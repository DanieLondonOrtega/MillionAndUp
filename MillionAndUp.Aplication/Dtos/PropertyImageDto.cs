
using Microsoft.AspNetCore.Http;

namespace MillionAndUp.Aplication.Dtos
{
    /// <summary>
    /// DTO for the transfer of property image data between the entry and the domain
    /// </summary>
    public class PropertyImageDto
    {
        public Guid? IdPropertyImage { get; set; }
        public Guid IdProperty { get; set; }
        public string File { get; set; }
        public IFormFile UploadFile { get; set; }
        public bool? Enabled { get; set; }
    }
}
