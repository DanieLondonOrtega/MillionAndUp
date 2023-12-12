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

            CreateMap<PropertyModel, PropertyDto>().ReverseMap();
            CreateMap<PropertyDto, Property>().ReverseMap();
            CreateMap<PropertyUpdateModel, PropertyDto>().ReverseMap();
            CreateMap<PropertyChangePriceModel, PropertyDto>().ReverseMap();

            CreateMap<PropertyImageModel, PropertyImageDto>().ReverseMap();
            CreateMap<PropertyImageDto, PropertyImage>().ReverseMap();
            CreateMap<PropertyImageUpdateModel, PropertyImageDto>().ReverseMap();
        }
    }
}
