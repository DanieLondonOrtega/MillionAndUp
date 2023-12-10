using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Domain.Entities
{
    /// <summary>
    /// Class with the information for authentication
    /// </summary>
    public class User
    {        
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}
