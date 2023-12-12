namespace MillionAndUp.API.Models
{
    /// <summary>
    /// Class to receive the data to be inserted from the property image
    /// </summary>
    public class PropertyImageModel
    {
        public Guid IdProperty { get; set; }
        public IFormFile UploadFile { get; set; }       
        public bool? Enabled { get; set; }
    }

    /// <summary>
    /// Class to receive the data to be modify from the property image
    /// </summary>
    public class PropertyImageUpdateModel : PropertyImageModel {
        public Guid IdPropertyImage { get; set; }
    }
}
