using AutoMapper;
using Model.Entities;
using NetWebApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            // AutoMapper Club
            CreateMap<Club, ClubDto>()
                .ForMember(dest => dest.Name, org => org.MapFrom(src => src.Name));
            CreateMap<ClubDto, Club>();
            CreateMap<ClubPostDto, Club>();

            
        }
    }
}
