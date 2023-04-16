using Entities;

namespace Repositories.Interfaces
{
    public interface IUserRepository
    {
        User AddUser(User newUser);
    }
}