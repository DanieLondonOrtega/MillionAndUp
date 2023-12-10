
using MillionAndUp.Aplication.Dtos;

namespace MillionAndUp.Aplication.Interfaces
{
    /// <summary>
    /// Interface to implement in the owner service
    /// </summary>
    public interface IUserService
    {
        bool Post(UserDto entity);
        bool Delete(string usuario);        
    }
}
