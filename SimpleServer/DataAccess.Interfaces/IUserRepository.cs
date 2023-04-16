using Entities;

namespace DataAccess.Interfaces
{
    public interface IUserRepository
    {
        User AddUser(User newUser);
    }
}