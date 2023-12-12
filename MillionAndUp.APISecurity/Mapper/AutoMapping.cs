using MillionAndUp.APISecurity.Models;
using MillionAndUp.Aplication.Dtos;
using MillionAndUp.Domain.Entities;

namespace MillionAndUp.APISecurity.Mapper
{
    public class AutoMapping : AutoMapper.Profile
    {
        public AutoMapping()
        {
            CreateMap<InfoTokenModel, InfoTokenDto>().ReverseMap();
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
