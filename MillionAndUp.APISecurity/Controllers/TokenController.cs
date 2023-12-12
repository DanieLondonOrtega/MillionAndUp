using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MillionAndUp.APISecurity.Models;
using MillionAndUp.Aplication.Dtos;
using MillionAndUp.Aplication.Interfaces;
using MillionAndUp.Common.Crypto;
using MillionAndUp.Common.Dto;

namespace MillionAndUp.APISecurity.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        /// <summary>
        /// The Token service
        /// </summary>
        private readonly ITokenService _service;
        private readonly IMapper _mapper;
        private readonly ICrypto _crypto;
        private readonly IConfiguration _configuration;

        public TokenController(ITokenService service, IMapper mapper, ICrypto crypto, IConfiguration configuration)
        {
            _service = service;
            _mapper = mapper;
            _crypto = crypto;
            _configuration = configuration;
        }
        /// <summary>
        /// Generate Token
        /// </summary>
        [HttpPost]
        public IActionResult GenerateToken([FromBody] InfoTokenModel request)
        {
            var options = _configuration.GetSection("Crypto").Get<CryptoDto>();
            if (options.Enabled)
            {
                request.Password = _crypto.Encrypt(request.Password, options);
            }
            var objRequest = _mapper.Map<InfoTokenDto>(request);
            (bool status, string jwt) = _service.GenerateToken(objRequest);
            if (status)
            {
                return Ok(new { Status = status, Data = jwt });
            }
            return Ok(new { Status = status, Data = string.Empty });
        }
    }
}
