using AutoMapper;
using SubNine.Data.Entities;
using SubNine.Data.Models;

namespace SubNine.Data.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDetail>();

            CreateMap<City, CityDetailMore>()
            .ForMember(
                dest => dest.Label,
                opt => opt.MapFrom(src => src.Name.Substring(0,2))
            );
            
            CreateMap<CityCreate, City>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name)
            );
            
        }
    }
}