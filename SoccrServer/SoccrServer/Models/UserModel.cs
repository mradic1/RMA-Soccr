namespace SoccrServer.Models
{
    class UserModel
    {
        public UserModel(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is UserModel))
                return false;
            UserModel secondUser = obj as UserModel;
            return this.Username == secondUser.Username && this.Password == secondUser.Password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
