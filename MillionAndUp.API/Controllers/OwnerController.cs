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
    public class OwnerController : ControllerBase
    {
        /// <summary>
        /// The owner service
        /// </summary>
        private readonly IOwnerService _service;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerService ownerService, IMapper mapper)
        {
            _service = ownerService;
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
        /// Insert a new Owner
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromForm] OwnerModel request)
        {
            var objRequest = _mapper.Map<OwnerDto>(request);
            return Ok(_service.Post(objRequest));
        }

        /// <summary>
        /// Update information Owner
        /// </summary>
        [HttpPut]
        public IActionResult Put([FromForm] OwnerUpdateModel request)
        {
            var objRequest = _mapper.Map<OwnerDto>(request);
            return Ok(_service.Put(objRequest));
        }

        /// <summary>
        /// Delete information Owner
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(_service.Delete(id));
        }
    }
}
