using Microsoft.AspNetCore.Mvc;

namespace SubNine.Api.Requests
{
    public class BaseRequest
    {
        [FromQuery(Name = "search")]
        public string Search { get; set; }

        [FromQuery(Name = "page")]
        public int Page { get; set; } = 1;
        
        [FromQuery(Name = "sort")]
        public string Sort { get; set; }
    }
}