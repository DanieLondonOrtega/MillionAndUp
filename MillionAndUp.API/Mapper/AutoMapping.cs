using MillionAndUp.API.Models;
using MillionAndUp.Aplication.Dtos;
using MillionAndUp.Domain.Entities;

namespace MillionAndUp.API.Mapper
{
    public class AutoMapping : AutoMapper.Profile
    {
        public AutoMapping()
        {
            CreateMap<OwnerModel, OwnerDto>().ReverseMap();
            CreateMap<OwnerDto, Owner>().ReverseMap();
            CreateMap<OwnerUpdateModel, OwnerDto>().ReverseMap();
        }
    }
}
