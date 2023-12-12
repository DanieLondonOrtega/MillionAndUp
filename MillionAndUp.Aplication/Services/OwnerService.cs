using AutoMapper;
using MillionAndUp.Aplication.Dtos;
using MillionAndUp.Aplication.Interfaces;
using MillionAndUp.Domain.Entities;
using MillionAndUp.Infrastructure.DataAccess.Repository;

namespace MillionAndUp.Aplication.Services
{
    /// <summary>
    /// Class to manage the business logic regarding Owner
    /// </summary>
    public class OwnerService : IOwnerService
    {
        private readonly IRepositoryBase<Owner> _ownerRepository;
        private readonly IMapper _mapper;
        private readonly IAzureBlobStorageService _azureBlobStorageService;
        public OwnerService(IRepositoryBase<Owner> ownerRepository, IMapper mapper, IAzureBlobStorageService azureBlobStorageService)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
            _azureBlobStorageService = azureBlobStorageService;
        }
        public bool Delete(Guid id)
        {
            var name = string.Format(Constants.Constants.RoutePhotoOwner, id.ToString());
            _azureBlobStorageService.DeleteAsync(name);
            return _ownerRepository.Delete(id);
        }

        public async Task<OwnerDto> Get(Guid id)
        {
            var result = await _ownerRepository.GetById(x => x.IdOwner == id);
            return _mapper.Map<OwnerDto>(result);
        }

        public async Task<IEnumerable<OwnerDto>> GetAll()
        {
            var result = await _ownerRepository.GetAll();
            return _mapper.Map<IEnumerable<OwnerDto>>(result);
        }

        public bool Post(OwnerDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException(String.Format(Constants.Constants.EntityIsRequerid, "Owner"));

            entity.IdOwner = Guid.NewGuid();

            if (entity.File != null)
            {
                var name = string.Format(Constants.Constants.RoutePhotoOwner, entity.IdOwner.ToString());
                entity.Photo = _azureBlobStorageService.UploadAsync(name, entity.File).Result;
            }
            var obj = _mapper.Map<Owner>(entity);
            return _ownerRepository.Add(obj);
        }

        public bool Put(OwnerDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException(String.Format(Constants.Constants.EntityIsRequerid, "Owner"));

            if (entity.File != null)
            {
                var name = string.Format(Constants.Constants.RoutePhotoOwner, entity.IdOwner.ToString());
                _azureBlobStorageService.DeleteAsync(name);
                entity.Photo = _azureBlobStorageService.UploadAsync(name, entity.File).Result;
            }

            var obj = _mapper.Map<Owner>(entity);
            return _ownerRepository.Update(obj);
        }
    }
}
