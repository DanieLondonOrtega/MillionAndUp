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
        public OwnerService(IRepositoryBase<Owner> ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }
        public bool Delete(Guid id)
        {
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
                throw new ArgumentNullException("Owner is requerid");

            entity.IdOwner = Guid.NewGuid();            
            var obj = _mapper.Map<Owner>(entity);
            return _ownerRepository.Add(obj);
        }

        public bool Put(OwnerDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Owner is requerid");

            var obj = _mapper.Map<Owner>(entity);
            return  _ownerRepository.Update(obj);
        }
    }
}
