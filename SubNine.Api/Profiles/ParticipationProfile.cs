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
            CreateMap<Participation, ParticipationDetail>().ReverseMap();
            CreateMap<Participation, ParticipationDetailMore>().ReverseMap();
            CreateMap<ParticipationCreate, Participation>().ReverseMap();
        }
    }
}