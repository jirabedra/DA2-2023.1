using Entities;

namespace SimpleServer
{
    public class UserInModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User ToEntity()
        {
            return new User()
            {
                FirstName = this.FirstName,
                LastName = this.LastName
            };
        }
    }
}