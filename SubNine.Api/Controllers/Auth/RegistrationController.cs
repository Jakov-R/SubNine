using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SubNine.Api.Helpers;
using SubNine.Api.Requests;
using SubNine.Api.Responses;
using SubNine.Api.Services;
using SubNine.Data.Entities;

namespace SubNine.Api.Controllers.Auth
{
    [Route("api/auth/register")]
    public class RegistrationController : BaseController
    {
        private readonly IAuthService authService;
        private readonly IMapper mapper;

        public RegistrationController(
            IAuthService authService,
            IMapper mapper   
        ) {
            this.mapper = mapper;
            this.authService = authService;
        }

        [HttpPost]
        public ActionResult<RegistrationResponse> Register(RegistrationRequest request)
        {
            var appUser = this.mapper.Map<AppUser>(request);

            /* register user: create the entity in database, hash the password, etc. */
            var userDetail = this.authService.Register(appUser);
            var token = JwtHelper.CreateFromUser(appUser);
            var response = new RegistrationResponse(userDetail, token);
            return response;
        }
    }
}