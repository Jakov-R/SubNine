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
            CreateMap<Participation, ParticipationDetail>();
            CreateMap<Participation, ParticipationDetailMore>();
            CreateMap<ParticipationCreate, Participation>();
        }
    }
}