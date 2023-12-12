using AutoMapper;
using MillionAndUp.Aplication.Dtos;
using MillionAndUp.Aplication.Interfaces;
using MillionAndUp.Domain.Entities;
using MillionAndUp.Infrastructure.DataAccess.Repository;

namespace MillionAndUp.Aplication.Services
{
    /// <summary>
    /// Class to manage the business logic regarding property trace
    /// </summary>
    public class PropertyTraceService : IPropertyTraceService
    {
        private readonly IRepositoryBase<PropertyTrace> _propertyTraceRepository;
        private readonly IMapper _mapper;
        public PropertyTraceService(IRepositoryBase<PropertyTrace> propertyTraceRepository, IMapper mapper)
        {
            _propertyTraceRepository = propertyTraceRepository;
            _mapper = mapper;
        }
        public bool Delete(Guid id)
        {
            return _propertyTraceRepository.Delete(id);
        }

        public async Task<PropertyTraceDto> Get(Guid id)
        {
            var result = await _propertyTraceRepository.GetById(x => x.IdPropertyTrace == id);
            return _mapper.Map<PropertyTraceDto>(result);
        }

        public async Task<IEnumerable<PropertyTraceDto>> GetAllById(Guid id)
        {
            var result = await _propertyTraceRepository.GetAll();
            var obj = result.Where(x => x.IdProperty == id);
            return _mapper.Map<IEnumerable<PropertyTraceDto>>(obj);
        }

        public bool Post(PropertyTraceDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException(String.Format(Constants.Constants.EntityIsRequerid, "Property Trace"));

            entity.IdPropertyTrace = Guid.NewGuid();
            var obj = _mapper.Map<PropertyTrace>(entity);
            return _propertyTraceRepository.Add(obj);
        }

        public bool Put(PropertyTraceDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException(String.Format(Constants.Constants.EntityIsRequerid, "Property Trace"));

            var obj = _mapper.Map<PropertyTrace>(entity);
            return _propertyTraceRepository.Update(obj);
        }
    }
}
