using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MillionAndUp.API.Models;
using MillionAndUp.Aplication.Dtos;
using MillionAndUp.Aplication.Interfaces;

namespace MillionAndUp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImageController : Controller
    {
        /// <summary>
        /// The property image service
        /// </summary>
        private readonly IPropertyImageService _service;
        private readonly IMapper _mapper;
        public PropertyImageController(IPropertyImageService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;   
        }

        /// <summary>
        /// Get property image information by ID 
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _service.Get(id);
            return Ok(result);
        }

        /// <summary>
        /// Gets all property images
        /// </summary>        
        [HttpGet("PropertyImage{id}")]
        public async Task<IActionResult> GetAll(Guid id)
        {
            var result = await _service.GetAllById(id);
            return Ok(result);
        }

        /// <summary>
        /// Insert a new property image
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromForm] PropertyImageModel request)
        {
            var objRequest = _mapper.Map<PropertyImageDto>(request);
            return Ok(_service.Post(objRequest));
        }

        /// <summary>
        /// Update information property image
        /// </summary>
        [HttpPut]
        public IActionResult Put([FromForm] PropertyImageUpdateModel request)
        {
            var objRequest = _mapper.Map<PropertyImageDto>(request);
            return Ok(_service.Put(objRequest));
        }

        /// <summary>
        /// Delete information property image
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(_service.Delete(id));
        }
    }
}
