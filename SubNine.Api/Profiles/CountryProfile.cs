using System;
using AutoMapper;
using SubNine.Data.Entities;
using SubNine.Data.Models;

namespace SubNine.Data.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDetail>().ReverseMap();

            CreateMap<Country, CountryDetailMore>()
            .ForMember(
                dest => dest.Label,
                opt => opt.MapFrom(src => src.Name.Substring(0,3))
            );

            CreateMap<CountryCreate, Country>().ReverseMap();
        }
    }
}