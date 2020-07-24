using System;
using AutoMapper;
using SubNineAPI.Entities;
using SubNineAPI.Entities.DTO;

namespace SubNineAPI.Profiles
{
    public class ParticipationProfile : Profile
    {
        public ParticipationProfile()
        {
            CreateMap<Participation, ParticipationDetailDTO>()
            .ForMember(
                dest => dest.Result,
                opt => opt.MapFrom(src => src.Result)
            );

            CreateMap<ParticipationCreateDTO, Participation>()
            .ForMember(
                dest => dest.Result,
                opt => opt.MapFrom(src => src.Result)
            );
        }
    }
}