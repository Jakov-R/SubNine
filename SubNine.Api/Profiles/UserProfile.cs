using AutoMapper;
using SubNine.Api.Requests.Auth;
using SubNine.Data.Entities;
using SubNine.Data.Models;

namespace SubNine.Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegistrationRequest, AppUser>().ReverseMap();
            CreateMap<UserDetail, AppUser>().ReverseMap();
        }
    }
}