using MillionAndUp.Aplication.Dtos;

namespace MillionAndUp.Aplication.Interfaces
{
    /// <summary>
    /// Interface to implement in the property service
    /// </summary>
    public interface IPropertyService
    {
        bool Post(PropertyDto entity);
        bool Put(PropertyDto entity);
        bool Delete(Guid id);
        Task<PropertyDto> Get(Guid id);
        Task<IEnumerable<PropertyDto>> GetFilter(string filter);
        Task<IEnumerable<PropertyDto>> GetAll();
        bool ChangePrice(PropertyDto entity);
    }
}
