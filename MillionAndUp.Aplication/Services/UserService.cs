using AutoMapper;
using MillionAndUp.Aplication.Dtos;
using MillionAndUp.Aplication.Interfaces;
using MillionAndUp.Common.Crypto;
using MillionAndUp.Domain.Entities;
using MillionAndUp.Infrastructure.DataAccess.Repository;

namespace MillionAndUp.Aplication.Services
{
    /// <summary>
    /// Class to manage the business logic regarding User
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IRepositoryBase<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepositoryBase<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public bool Delete(string usuario)
        {
            return _userRepository.Delete(usuario);
        }

        public bool Post(UserDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException("User is requerid");
            var obj = _mapper.Map<User>(entity);
            return _userRepository.Add(obj);
        }
    }
}
