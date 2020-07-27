using System;
using AutoMapper;
using SubNine.Data.Entities;
using SubNine.Data.Models;

namespace SubNine.Data.Profiles
{
    public class RangListProfile : Profile
    {
        public RangListProfile()
        {
            CreateMap<RangList, RangListDetailDTO>()
            .ForMember(
                dest => dest.Place,
                opt => opt.MapFrom(src => src.Place)
            );

            CreateMap<RangListCreateDTO, RangList>()
            .ForMember(
                dest => dest.Place,
                opt => opt.MapFrom(src => src.Place)
            );
        }
    }
}