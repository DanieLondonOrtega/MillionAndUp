using MillionAndUp.Aplication.Dtos;

namespace MillionAndUp.Aplication.Interfaces
{
    /// <summary>
    /// Interface to implement in the property image service
    /// </summary>
    public interface IPropertyImageService
    {
        bool Post(PropertyImageDto entity);
        bool Put(PropertyImageDto entity);
        bool Delete(Guid id);
        Task<PropertyImageDto> Get(Guid id);
        Task<IEnumerable<PropertyImageDto>> GetAllById(Guid id);
    }
}
