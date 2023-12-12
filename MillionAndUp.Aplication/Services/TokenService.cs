using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MillionAndUp.Aplication.Dtos;
using MillionAndUp.Aplication.Interfaces;
using MillionAndUp.Domain.Entities;
using MillionAndUp.Infrastructure.DataAccess.Repository;

namespace MillionAndUp.Aplication.Services
{
    /// <summary>
    /// Class to manage the business logic generate adn validate token
    /// </summary>
    public class TokenService : ITokenService
    {
        private readonly IRepositoryBase<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly IOptionsSnapshot<Jwt> _jwtOption;

        public TokenService(IOptionsSnapshot<Jwt> jwtOption, IRepositoryBase<User> userRepository, IMapper mapper)
        {
            _jwtOption = jwtOption;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public (bool status, string jwt) GenerateToken(InfoTokenDto entity)
        {
            if (IsUser(entity))
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOption.Value.Key));
                var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                //var claims = new[]
                //{
                //    new Claim(JwtRegisteredClaimNames.Sub,""),
                //};

                var token = new JwtSecurityToken(
                    null,
                    null,
                    null,
                    expires: DateTime.UtcNow.AddDays(5),
                    signingCredentials: singIn
                    );

                return (true, new JwtSecurityTokenHandler().WriteToken(token));
            }
            else
            {
                return (false, string.Empty);
            }
        }

        public bool IsUser(InfoTokenDto entity)
        {            
            UserDto securityUser = GetByUsuario(entity.Usuario);
            if (securityUser != null)
            {
                return securityUser.Usuario == entity.Usuario && securityUser.Password == entity.Password; 
            }
            return false;
        }

        public UserDto GetByUsuario(string usuario)
        {
            IQueryable<User> result = _userRepository.GetAll().Result;
            
            return _mapper.Map<UserDto>(result.Where(x => x.Usuario == usuario).FirstOrDefault());
        }
    }
}
