using System.Collections.Generic;
using AutoMapper;
using SubNine.Api.Requests.Athletes;
using SubNine.Api.Responses.Athletes;
using SubNine.Core.Repositories;
using SubNine.Data.Models;

namespace SubNine.Api.Services
{
    public interface IAthleteService
    {
        AthletePaginatedResponse GetPaginatedResponse(PaginatedAthleteRequest request);
    }

    public class AthleteService : IAthleteService
    {
        private readonly IAthleteRepository athleteRepository;
        private readonly IMapper mapper;

        public AthleteService(
            IAthleteRepository athleteRepository,
            IMapper mapper
        )
        {
            this.athleteRepository = athleteRepository;
            this.mapper = mapper;
        }

        public AthletePaginatedResponse GetPaginatedResponse(PaginatedAthleteRequest request)
        {
            var athletes = this.athleteRepository.GetPaginatedAthletes(
                request.Page,
                request.Search,
                request.Sort
            );

            int count = this.athleteRepository.Count(request.Search);

            var athletesDTO = this.mapper.Map<IEnumerable<AthleteDetailMore>>(athletes);

            var response = new AthletePaginatedResponse(athletesDTO, request.Page, count, this.athleteRepository.PerPage);
            return response;
        }
    }
}