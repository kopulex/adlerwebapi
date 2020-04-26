using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdlerCatalogueWebApi.Auth
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
    }

    public class UserService : IUserService
    {
        /// <summary>
        /// Hardcoded user list
        /// </summary>
        private List<User> _users = new List<User>
        {
            new User { Id = 1, Username = "test", Password = "test" }
        };

        /// <summary>
        /// Used to authenticate the user request
        /// </summary>
        /// <param name="username">BASIC AUTENTICATION user name</param>
        /// <param name="password">BASIC AUTENTICATION user password</param>
        /// <returns>Returns the user of null if not found/autorized.</returns>
        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details without password
            user.Password = null;
            return user;
        }
    }
}
