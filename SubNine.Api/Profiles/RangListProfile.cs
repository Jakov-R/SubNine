using System;
using AutoMapper;
using SubNine.Data.Entities;
using SubNine.Data.Models;

namespace SubNine.Data.Profiles
{
    public class RangListProfile : Profile
    {
        public RangListProfile()
        {
            CreateMap<RangList, RangListDetail>();
            CreateMap<RangList, RangListDetailMore>();
            CreateMap<RangListCreate, RangList>();
        }
    }
}