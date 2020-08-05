using System;
using AutoMapper;
using SubNine.Data.Entities;
using SubNine.Data.Models;

namespace SubNine.Data.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDetail>().ReverseMap();
            CreateMap<Event, EventDetailMore>().ReverseMap();
            CreateMap<EventCreate, Event>().ReverseMap();
        }
    }
}