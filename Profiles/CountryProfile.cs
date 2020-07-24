using System;
using AutoMapper;
using SubNineAPI.Entities;
using SubNineAPI.Entities.DTO;

namespace SubNineAPI.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDetailDTO>()
            .ForMember(
                dest => dest.Label,
                opt => opt.MapFrom(src => src.Name.Substring(0,3))
            );

            CreateMap<CountryCreateDTO, Country>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name)
            );
        }
    }
}