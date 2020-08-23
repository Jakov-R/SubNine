using SubNine.Data.Entities;
using SubNine.Data.Models;

namespace SubNine.Api.Responses
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public UserDetail User { get; set; }

        public LoginResponse(UserDetail user, string token)
        {
            this.User = user;
            this.Token = token;
        }
    }
}