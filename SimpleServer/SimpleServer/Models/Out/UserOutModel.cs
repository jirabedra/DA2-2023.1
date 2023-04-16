using Entities;

namespace SimpleServer
{
    public class UserOutModel
    {
        public UserOutModel(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}