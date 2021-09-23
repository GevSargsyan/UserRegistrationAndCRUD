using AutoMapper;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegistrationandCRUD.DAL.Entities;

namespace DAL.Mapping
{
    public class DataAccessMapingProfile : Profile
    {
        public DataAccessMapingProfile()
        {
            CreateMap<UserDB, Core.Entities.UserCore>().ReverseMap();
            CreateMap<UserUpdate, UserDB>().ReverseMap();

        }
        
    }
}
