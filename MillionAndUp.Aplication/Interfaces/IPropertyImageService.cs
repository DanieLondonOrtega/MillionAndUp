using MillionAndUp.Aplication.Dtos;

namespace MillionAndUp.Aplication.Interfaces
{
    public interface IPropertyImageService
    {
        bool Post(PropertyImageDto entity);
        bool Put(PropertyImageDto entity);
        bool Delete(Guid id);
        Task<PropertyImageDto> Get(Guid id);
        Task<IEnumerable<PropertyImageDto>> GetAllById(Guid id);
    }
}
