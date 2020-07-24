using System;
using AutoMapper;
using SubNineAPI.Entities;
using SubNineAPI.Entities.DTO;

namespace SubNineAPI.Profiles
{
    public class AthleteProfile : Profile
    {
        public AthleteProfile()
        {
            CreateMap<Athlete, AthleteDetailDTO>()
            .ForMember(
                dest => dest.YearsOld,
                opt => opt.MapFrom(src => DateTime.Now.Year - src.DateOfBirth.Year))
            .ForMember(
                dest => dest.FullName,
                opt => opt.MapFrom(src => src.FirstName + " " + src.LastName)
            );

            CreateMap<AthleteCreateDTO, Athlete>()
            .ForMember(
                dest => dest.DateOfBirth,
                opt => opt.MapFrom(src => new DateTime(src.Year, src.Month, src.Day))
            );
        }
    }
}