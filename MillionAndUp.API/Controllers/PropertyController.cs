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
    public class PropertyController : Controller
    {
        /// <summary>
        /// The property service
        /// </summary>
        private readonly IPropertyService _service;
        private readonly IMapper _mapper;

        public PropertyController(IPropertyService propertyService, IMapper mapper)
        {
            _service = propertyService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all property owners
        /// </summary>        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// Get owner information by ID 
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _service.Get(id);
            return Ok(result);
        }

        /// <summary>
        /// Get owner information by ID 
        /// </summary>
        [HttpGet("Property{filter}")]
        public async Task<IActionResult> GetFilter(string filter)
        {
            var result = await _service.GetFilter(filter);
            return Ok(result);
        }

        /// <summary>
        /// Insert a new Porperty
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromBody] PropertyModel request)
        {
            var objRequest = _mapper.Map<PropertyDto>(request);
            return Ok(_service.Post(objRequest));
        }

        /// <summary>
        /// Update information Property
        /// </summary>
        [HttpPut]
        public IActionResult Put([FromBody] PropertyModel request)
        {
            var objRequest = _mapper.Map<PropertyDto>(request);
            return Ok(_service.Put(objRequest));
        }

        /// <summary>
        /// Delete information Property
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(_service.Delete(id));
        }

        /// <summary>
        /// Change Price Property
        /// </summary>
        [HttpPut("changePrice")]
        public IActionResult ChangePrice([FromBody] PropertyChangePriceModel request)
        {
            var objRequest = _mapper.Map<PropertyDto>(request);
            return Ok(_service.ChangePrice(objRequest));
        }
    }
}
