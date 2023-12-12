using AutoMapper;
using MillionAndUp.Aplication.Dtos;
using MillionAndUp.Aplication.Interfaces;
using MillionAndUp.Domain.Entities;
using MillionAndUp.Infrastructure.DataAccess.Repository;

namespace MillionAndUp.Aplication.Services
{
    /// <summary>
    /// Class to manage the business logic regarding Proprty
    /// </summary>
    public class PropertyService : IPropertyService
    {
        private readonly IRepositoryBase<Property> _propertyRepository;        
        private readonly IMapper _mapper;
        public PropertyService(IRepositoryBase<Property> propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        public bool Delete(Guid id)
        {
            return _propertyRepository.Delete(id);
        }

        public async Task<PropertyDto> Get(Guid id)
        {
            var result = await _propertyRepository.GetById(x => x.IdProperty == id);
            return _mapper.Map<PropertyDto>(result);
        }
        public async Task<IEnumerable<PropertyDto>> GetFilter(string filter)
        {
            var result = await _propertyRepository.GetAll();
            var query = result.Where(x => x.Name.Contains(filter) || x.Address.Contains(filter) || x.CodeInternal.Contains(filter));
            return _mapper.Map<IEnumerable<PropertyDto>>(query);
        }
        public async Task<IEnumerable<PropertyDto>> GetAll()
        {
            var result = await _propertyRepository.GetAll();
            return _mapper.Map<IEnumerable<PropertyDto>>(result);
        }

        public bool Post(PropertyDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException(String.Format(Constants.Constants.EntityIsRequerid, "Property"));

            entity.IdProperty = Guid.NewGuid();
            var obj = _mapper.Map<Property>(entity);
            return _propertyRepository.Add(obj);
        }

        public bool Put(PropertyDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException(String.Format(Constants.Constants.EntityIsRequerid, "Property"));

            var obj = _mapper.Map<Property>(entity);
            return _propertyRepository.Update(obj);
        }

        public bool ChangePrice(PropertyDto entity)
        {
            Task<PropertyDto> property = Get(entity.IdProperty.Value);
            property.Result.Price = entity.Price;
            _propertyRepository.Clear();
            var obj = _mapper.Map<Property>(property.Result);
            return _propertyRepository.Update(obj);
        }
    }
}
