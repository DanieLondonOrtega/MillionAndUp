using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MillionAndUp.APISecurity.Models;
using MillionAndUp.Aplication.Dtos;
using MillionAndUp.Aplication.Interfaces;
using MillionAndUp.Common.Crypto;
using MillionAndUp.Common.Dto;

namespace MillionAndUp.APISecurity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        /// <summary>
        /// The user service
        /// </summary>
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        private readonly ICrypto _crypto;
        private readonly IConfiguration _configuration;

        public UserController(IUserService service, IMapper mapper, ICrypto crypto, IConfiguration configuration)
        {
            _service = service;
            _mapper = mapper;
            _crypto = crypto;
            _configuration = configuration;
        }

        /// <summary>
        /// Insert a new User
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromBody] UserModel request)
        {
            var options = _configuration.GetSection("Crypto").Get<CryptoDto>();
            if (options.Enabled)
            {
                request.Password = _crypto.Encrypt(request.Password,options);
            }
            var objRequest = _mapper.Map<UserDto>(request);
            return Ok(_service.Post(objRequest));
        }
        /// <summary>
        /// Delete information User
        /// </summary>
        [HttpDelete("{usuario}")]
        public IActionResult Delete(string usuario)
        {
            return Ok(_service.Delete(usuario));
        }
    }
}
