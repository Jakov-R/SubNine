using System;
using AutoMapper;
using SubNine.Data.Entities;
using SubNine.Data.Models;

namespace SubNine.Data.Profiles
{
    public class ClubProfile : Profile
    {
        public ClubProfile()
        {
            CreateMap<Club, ClubDetail>();
            
            CreateMap<Club, ClubDetailMore>()
            .ForMember(
                dest => dest.ShirtColor,
                opt => opt.MapFrom(src => "Boja dresa: " + src.ShirtColor)
            );

            CreateMap<ClubCreate, Club>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name)
            );
        }
    }
}