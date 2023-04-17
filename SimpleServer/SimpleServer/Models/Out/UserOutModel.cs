using Entities;
using System.ComponentModel.DataAnnotations;

namespace SimpleServer
{
    public class UserOutModel
    {
        public UserOutModel(User user)
        {

            FirstName = user.FirstName;
            LastName = user.LastName;
            Id = user.Id;
            Timestamp = user.Timestamp;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Timestamp { get; set; }
    }
}