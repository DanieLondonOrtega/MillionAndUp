
namespace MillionAndUp.API.Models
{
    /// <summary>
    /// Class to receive the data to be inserted from the owner
    /// </summary>
    public class OwnerModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public IFormFile File { get; set; }
        public DateTime Birthday { get; set; }
    }

    /// <summary>
    /// Class to receive the data to be modify from the owner
    /// </summary>
    public class OwnerUpdateModel : OwnerModel
    {   
        public Guid IdOwner { get; set; }
    }
}

