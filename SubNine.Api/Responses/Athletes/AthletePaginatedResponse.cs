using System.Collections.Generic;
using SubNine.Data.Entities;
using SubNine.Data.Models;

namespace SubNine.Api.Responses.Athletes
{
    public class AthletePaginatedResponse : BaseResponse
    {
        public AthletePaginatedResponse()
        {

        }

        public AthletePaginatedResponse(IEnumerable<AthleteDetailMore> athletes, int page, int count, int perPage)
        {
            Athletes = athletes;
            Count = count;
            PerPage = perPage;
            
            Success = true;
        }

        public IEnumerable<AthleteDetailMore> Athletes { get; set; }
        public int Count { get; set ;}
        public int PerPage { get; set; }
        public int Page { get; set; } = 1;
    }
}