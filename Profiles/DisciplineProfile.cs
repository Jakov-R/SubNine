using System;
using AutoMapper;
using SubNineAPI.Entities;
using SubNineAPI.Entities.DTO;

namespace SubNineAPI.Profiles
{
    public class DisciplineProfile : Profile
    {
        public DisciplineProfile()
        {
            CreateMap<Discipline, DisciplineDetailDTO>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name)
            );

            CreateMap<DisciplineCreateDTO, Discipline>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name)
            );
        }
    }
}