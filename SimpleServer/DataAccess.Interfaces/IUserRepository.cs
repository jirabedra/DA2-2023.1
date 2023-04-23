using Entities;

namespace DataAccess.Interfaces
{
    public interface IUserRepository
    {
        User AddUser(User newUser);
        User Get(Func<User, bool> func);
        bool Exist(Func<User, bool> func);
    }
}