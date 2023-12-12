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
    public class PropertyTraceController : Controller
    {
        /// <summary>
        /// The property service
        /// </summary>
        private readonly IPropertyTraceService _service;
        private readonly IMapper _mapper;
        public PropertyTraceController(IPropertyTraceService propertyTraceService, IMapper mapper)
        {
            _service = propertyTraceService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get property trace information by ID 
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _service.Get(id);
            return Ok(result);
        }

        /// <summary>
        /// Gets all property trace
        /// </summary>        
        [HttpGet("PropertyTrace{id}")]
        public async Task<IActionResult> GetAll(Guid id)
        {
            var result = await _service.GetAllById(id);
            return Ok(result);
        }

        /// <summary>
        /// Delete information property trace
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(_service.Delete(id));
        }

        /// <summary>
        /// Insert a new property trace
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromBody] PropertyTraceModel request)
        {
            var objRequest = _mapper.Map<PropertyTraceDto>(request);
            return Ok(_service.Post(objRequest));
        }

        /// <summary>
        /// Update information property trace
        /// </summary>
        [HttpPut]
        public IActionResult Put([FromBody] PropertyTraceUpdateModel request)
        {
            var objRequest = _mapper.Map<PropertyTraceDto>(request);
            return Ok(_service.Put(objRequest));
        }

    }
}
