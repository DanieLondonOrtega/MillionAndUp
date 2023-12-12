using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Domain.Entities
{
    /// <summary>
    /// Class Information Property Image
    /// </summary>
    public class PropertyImage
    {
        public Guid IdPropertyImage { get; set; }
        public Guid IdProperty { get; set; }
        public string File { get; set; }
        public bool? Enabled { get; set; }
        public Property Property { get; set; }
    }
}
