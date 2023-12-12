namespace MillionAndUp.API.Models
{
    /// <summary>
    /// Class to receive the data to be inserted from the property
    /// </summary>
    public class PropertyModel
    {
        public Guid IdOwner { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string CodeInternal { get; set; }
        public int Year { get; set; }
    }
    /// <summary>
    /// Class to receive the data to be modify from the property
    /// </summary>
    public class PropertyUpdateModel : PropertyModel
    {
        public Guid IdProperty { get; set; }
    }

    /// <summary>
    /// Class to receive the data to be change price from the property
    /// </summary>
    public class PropertyChangePriceModel
    {
        public Guid IdProperty { get; set; }
        public decimal Price { get; set; }
    }
}
