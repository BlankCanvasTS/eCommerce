using eCommerceProject.Data;
using Microsoft.EntityFrameworkCore;

namespace eCommerceProject.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class AuthenticationService
    {
        private readonly eCommerceProjectContext _dbContext;

        public AuthenticationService()
        {
        }

        public AuthenticationService(eCommerceProjectContext dbContext)
        {
            _dbContext = dbContext;
        }
        public static async Task<bool> AuthenticateUserAsync(string username, string password)
        {
            // TODO: Add code to validate the user's credentials against a database or other authentication provider
            // Return true if the user is authenticated, false otherwise

            var users = new List<User>
    {
                
        new User { Username = "user1", Password = "password1" },
        new User { Username = "user2", Password = "password2" },
        new User { Username = "user3", Password = "password3" }
    };


            var user = await _dbContext.LoginModel.FirstOrDefaultAsync(p => p.Username == username && p.password == password);

            return user != null;
        }

        internal object AuthenticateUser(object username, string password)
        {
            throw new NotImplementedException();
        }
    }

}
