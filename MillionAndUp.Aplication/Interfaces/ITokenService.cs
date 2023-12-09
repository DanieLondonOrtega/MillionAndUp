using MillionAndUp.Aplication.Dtos;

namespace MillionAndUp.Aplication.Interfaces
{
    /// <summary>
    /// Interface to implement in the Token service
    /// </summary>
    public interface ITokenService
    {
        public (bool status, string jwt) GenerateToken(InfoTokenDto entity);
        public bool IsUser(InfoTokenDto entity);


    }
}
