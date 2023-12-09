namespace MillionAndUp.Domain.Entities
{
    /// <summary>
    /// Class Information Owner Property.
    /// </summary>
    public class Owner
    {
        /// <summary>
        /// Gets or sets the identifier owner.
        /// </summary>        
        public Guid IdOwner { get; set; }

        /// <summary>
        /// Gets or sets the name owner.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address owner.
        /// </summary>
        public string? Address { get; set; }
        /// <summary>
        /// Gets or sets the photo owner.
        /// </summary>
        public byte[]? Photo { get; set; }

        /// <summary>
        /// Gets or sets the birthday owner.
        /// </summary>
        public DateTime Birthday { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}
