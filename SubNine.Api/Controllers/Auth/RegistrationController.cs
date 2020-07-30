using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SubNine.Api.Requests;
using SubNine.Api.Responses;
using SubNine.Core.Services;
using SubNine.Data.Entities;

namespace SubNine.Api.Controllers.Auth
{
    [Route("api/auth/register")]
    public class RegistraionController : BaseController
    {
        private readonly IAuthService authService;
        private readonly IMapper mapper;

        public RegistraionController(
            IAuthService authService,
            IMapper mapper
        )
        {
            this.authService = authService;
            this.mapper = mapper;
        }

        [HttpPost]
        public ActionResult<RegistrationResponse> Register(RegistrationRequest request)
        {
            var user = this.mapper.Map<AppUser>(request);
            user = this.authService.Register(user);

            var response = new RegistrationResponse();
            response.User = user;
            response.Token = "";

            return response;
        }
    }
}