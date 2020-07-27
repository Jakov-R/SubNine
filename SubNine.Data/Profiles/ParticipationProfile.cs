using System;
using AutoMapper;
using SubNine.Data.Entities;
using SubNine.Data.Models;

namespace SubNine.Data.Profiles
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