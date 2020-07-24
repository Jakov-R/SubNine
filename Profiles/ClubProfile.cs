using System;
using AutoMapper;
using SubNineAPI.Entities;
using SubNineAPI.Entities.DTO;

namespace SubNineAPI.Profiles
{
    public class ClubProfile : Profile
    {
        public ClubProfile()
        {
            CreateMap<Club, ClubDetailDTO>()
            .ForMember(
                dest => dest.ShirtColor,
                opt => opt.MapFrom(src => "Boja dresa: " + src.ShirtColor)
            );

            CreateMap<ClubCreateDTO, Club>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name)
            );
        }
    }
}