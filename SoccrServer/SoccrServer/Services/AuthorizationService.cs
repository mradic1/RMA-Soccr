using SoccrServer.Models;

namespace SoccrServer.Services
{
    public class AuthorizationService
    {
        private List<UserModel> _users;

        public AuthorizationService()
        {
            _users = new List<UserModel>();
            _users.Add(new UserModel("admin", "admin"));
            _users.Add(new UserModel("milos", "milos"));
            _users.Add(new UserModel("user", "user"));
        }

        public bool Authorize(string username, string password)
        {
            UserModel newUser = new UserModel(username, password);
            return _users.Contains(newUser);
        }
    }


}
