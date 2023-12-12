using AutoMapper;
using MillionAndUp.Aplication.Dtos;
using MillionAndUp.Aplication.Interfaces;
using MillionAndUp.Domain.Entities;
using MillionAndUp.Infrastructure.DataAccess.Repository;

namespace MillionAndUp.Aplication.Services
{
    public class PropertyImageService : IPropertyImageService
    {
        private readonly IRepositoryBase<PropertyImage> _propertyimageRepository;
        private readonly IMapper _mapper;
        private readonly IAzureBlobStorageService _azureBlobStorageService;

        public PropertyImageService(IRepositoryBase<PropertyImage> propertyimageRepository, IMapper mapper, IAzureBlobStorageService azureBlobStorageService)
        {
            _propertyimageRepository = propertyimageRepository;
            _mapper = mapper;
            _azureBlobStorageService = azureBlobStorageService;
        }
        public bool Delete(Guid id)
        {
            var name = string.Format(Constants.Constants.RouteImageProperty, id.ToString());
            _azureBlobStorageService.DeleteAsync(name);
            return _propertyimageRepository.Delete(id);
        }

        public async Task<PropertyImageDto> Get(Guid id)
        {
            var result = await _propertyimageRepository.GetById(x => x.IdPropertyImage == id);
            return _mapper.Map<PropertyImageDto>(result);
        }

        public async Task<IEnumerable<PropertyImageDto>> GetAllById(Guid id)
        {
            var result = await _propertyimageRepository.GetAll();
            var obj = result.Where(x => x.IdProperty == id);
            return _mapper.Map<IEnumerable<PropertyImageDto>>(obj);
        }

        public bool Post(PropertyImageDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException(String.Format(Constants.Constants.EntityIsRequerid, "Property Image"));

            entity.IdPropertyImage = Guid.NewGuid();
            entity.Enabled = entity.Enabled == null || entity.Enabled.Value;
            if (entity.UploadFile != null)
            {
                var name = string.Format(Constants.Constants.RouteImageProperty, entity.IdPropertyImage.ToString());
                entity.File = _azureBlobStorageService.UploadAsync(name, entity.UploadFile).Result;
            }
            var obj = _mapper.Map<PropertyImage>(entity);
            return _propertyimageRepository.Add(obj);
        }

        public bool Put(PropertyImageDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException(String.Format(Constants.Constants.EntityIsRequerid, "Property Image"));

            if (entity.File != null)
            {
                var name = string.Format(Constants.Constants.RouteImageProperty, entity.IdPropertyImage.ToString());
                _azureBlobStorageService.DeleteAsync(name);
                entity.File = _azureBlobStorageService.UploadAsync(name, entity.UploadFile).Result;
            }
            var obj = _mapper.Map<PropertyImage>(entity);
            return _propertyimageRepository.Update(obj);
        }
    }
}
