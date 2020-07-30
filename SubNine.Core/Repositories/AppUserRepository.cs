using SubNine.Data.Database;
using SubNine.Data.Entities;

namespace SubNine.Core.Repositories
{
    public interface IAppUserRepository {
        AppUser Login(string username, string password);
        AppUser Register(string username, string password);
    }

    public class AppUserRepository : IAppUserRepository
    {
        private readonly ApplicationContext context;
        public AppUserRepository(ApplicationContext context) => this.context = context;

        public AppUser Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public AppUser Register(string email, string hash)
        {
            var user = new AppUser(email, hash);
            this.context.Users.Add(user);

            return user;
        }
    }
}