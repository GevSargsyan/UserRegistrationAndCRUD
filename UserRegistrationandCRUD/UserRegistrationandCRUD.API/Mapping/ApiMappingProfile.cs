using AutoMapper;
using Core.Entities;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using UserRegistrationandCRUD.API.Entities;

namespace UserRegistrationandCRUD.API.Mapping
{
    public class ApiMappingProfile : Profile
    {

        public ApiMappingProfile()
        {
            CreateMap<UserRegister, UserDB>().ForMember(
            dest => dest.UserName,
            opt => opt.MapFrom(src => src.Email));

            CreateMap<UserCore, UserModelView>();
        }

    }
}
