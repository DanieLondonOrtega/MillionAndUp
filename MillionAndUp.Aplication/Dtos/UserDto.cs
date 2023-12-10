using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Aplication.Dtos
{
    /// <summary>
    /// DTO for the transfer of user data between the entry and the domain
    /// </summary>
    public class UserDto
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}
