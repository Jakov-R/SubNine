using System;
using AutoMapper;
using SubNine.Api.Requests.Athletes;
using SubNine.Data.Entities;
using SubNine.Data.Models;

namespace SubNine.Data.Profiles
{
    public class AthleteProfile : Profile
    {
        public AthleteProfile()
        {
            CreateMap<Athlete, AthleteDetail>()
            .ForMember(
                dest => dest.YearsOld,
                opt => opt.MapFrom(src => DateTime.Now.Year - src.DateOfBirth.Year))
            .ForMember(
                dest => dest.FullName,
                opt => opt.MapFrom(src => src.FirstName + " " + src.LastName)
            );

            CreateMap<Athlete, AthleteDetailMore>()
            .ForMember(
                dest => dest.YearsOld,
                opt => opt.MapFrom(src => DateTime.Now.Year - src.DateOfBirth.Year))
            .ForMember(
                dest => dest.FullName,
                opt => opt.MapFrom(src => src.FirstName + " " + src.LastName)
            );

            CreateMap<AthleteCreate, Athlete>()
            .ForMember(
                dest => dest.DateOfBirth,
                opt => opt.MapFrom(src => new DateTime(src.Year, src.Month, src.Day))
            );

            //CreateMap<Athlete, AthleteDetailMore>().ReverseMap();
        }
    }
}