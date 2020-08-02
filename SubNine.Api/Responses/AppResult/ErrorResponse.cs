using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SubNine.Api.Responses.AppResult
{
    public class ErrorResponse
    {

        public ErrorResponse(ModelStateDictionary modelState)
        {
            Errors = modelState.SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage)
                .ToArray();
        }

        public IEnumerable<string> Errors { get; }
        public bool Success { get; set; } = false;

    }
}