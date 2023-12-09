using MillionAndUp.Aplication.Dtos;
using MillionAndUp.Domain.Entities;

namespace MillionAndUp.Aplication.Interfaces
{
    /// <summary>
    /// Interface to implement in the owner service
    /// </summary>
    public interface IOwnerService
    {
        bool Post(OwnerDto entity);
        bool Put(OwnerDto entity);
        bool Delete(Guid id);
        Task<OwnerDto> Get(Guid id);
        Task<IEnumerable<OwnerDto>> GetAll();
    }
}
