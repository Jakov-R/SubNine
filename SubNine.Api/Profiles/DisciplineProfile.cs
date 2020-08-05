using System;
using AutoMapper;
using SubNine.Data.Entities;
using SubNine.Data.Models;

namespace SubNine.Data.Profiles
{
    public class DisciplineProfile : Profile
    {
        public DisciplineProfile()
        {
            CreateMap<Discipline, DisciplineDetail>().ReverseMap();

            CreateMap<Discipline, DisciplineDetailMore>().ReverseMap();

            CreateMap<DisciplineCreate, Discipline>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name)
            );
        }
    }
}