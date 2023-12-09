using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MillionAndUp.Aplication.Dtos;
using MillionAndUp.Aplication.Interfaces;
using MillionAndUp.Domain.Entities;
using MillionAndUp.Infrastructure.DataAccess.Repository;

namespace MillionAndUp.Aplication.Services
{
    public class TokenService : ITokenService
    {
        Login securityInfo = new Login() {
            Usuario = "admin",
            Password = "admin"
        };
        public (bool status, string jwt) GenerateToken(InfoTokenDto entity)
        {
            throw new NotImplementedException();
        }

        public bool IsUser(InfoTokenDto entity)
        {
            return securityInfo.Usuario == entity.Usuario && securityInfo.Password == entity.Password; 
        }
    }
}
