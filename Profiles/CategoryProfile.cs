using AutoMapper;
using SubNineAPI.Entities;
using SubNineAPI.Entities.DTO;

namespace SubNineAPI.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDetailDTO>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name)
            );

            CreateMap<CategoryCreateDTO, Category>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name)
            );
        }
    }
}