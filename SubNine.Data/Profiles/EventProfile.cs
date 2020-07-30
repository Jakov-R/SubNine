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
            CreateMap<Event, EventDetail>();
            CreateMap<Event, EventDetailMore>();
            CreateMap<EventCreate, Event>();
        }
    }
}