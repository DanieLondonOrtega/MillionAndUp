using MillionAndUp.Aplication.Dtos;

namespace MillionAndUp.Aplication.Interfaces
{
    /// <summary>
    /// Interface to implement in the property trace service
    /// </summary>
    public interface IPropertyTraceService
    {
        bool Post(PropertyTraceDto entity);
        bool Put(PropertyTraceDto entity);
        bool Delete(Guid id);
        Task<PropertyTraceDto> Get(Guid id);
        Task<IEnumerable<PropertyTraceDto>> GetAllById(Guid id);
    }
}
