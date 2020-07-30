using AutoMapper;
using SubNine.Data.Entities;
using SubNine.Data.Models;

namespace SubNine.Data.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDetail>();

            CreateMap<Category, CategoryDetailMore>();

            CreateMap<CategoryCreate, Category>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name)
            );
        }
    }
}