namespace MillionAndUp.API.Models
{
    /// <summary>
    /// Class to receive the data to be inserted from the property trace
    /// </summary>
    public class PropertyTraceModel
    {
        public Guid IdProperty { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal Tax { get; set; }
    }

    /// <summary>
    /// Class to receive the data to be modify from the property trace
    /// </summary>
    public class PropertyTraceUpdateModel : PropertyTraceModel
    {
        public Guid IdPropertyTrace { get; set; }
    }
}
