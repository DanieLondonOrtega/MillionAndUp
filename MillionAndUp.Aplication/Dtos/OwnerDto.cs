using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MillionAndUp.Aplication.Dtos
{
    /// <summary>
    /// DTO for the transfer of owner data between the entry and the domain
    /// </summary>
    public class OwnerDto
    {
        public Guid? IdOwner { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public IFormFile File { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
    }
}
