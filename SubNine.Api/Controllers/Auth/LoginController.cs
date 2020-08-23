using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SubNine.Api.Requests.Auth;
using SubNine.Api.Responses;
using SubNine.Api.Services;

namespace SubNine.Api.Controllers.Auth
{
    [Route("api/auth/login")]
    public class LoginController : BaseController
    {
        private readonly IAuthService authService;
        private readonly IMapper mapper;

        public LoginController(
            IAuthService authService,
            IMapper mapper
        ) {
            this.mapper = mapper;
            this.authService = authService;
        }

        [HttpPost]
        public ActionResult<LoginResponse> Login([FromBody] LoginRequest request)
        {

            var token = this.authService.Login(request.Email, request.Password);
            return new LoginResponse(null, token);
        }
    }
}