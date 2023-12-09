using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Aplication.Dtos
{
    /// <summary>
    /// DTO for the transfer of owner data between the entry and the domain
    /// </summary>
    public class OwnerDto
    {
        public Guid? IdOwner { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public byte[]? Photo { get; set; }
        public DateTime Birthday { get; set; }
    }
}
