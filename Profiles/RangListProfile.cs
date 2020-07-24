using System;
using AutoMapper;
using SubNineAPI.Entities;
using SubNineAPI.Entities.DTO;

namespace SubNineAPI.Profiles
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