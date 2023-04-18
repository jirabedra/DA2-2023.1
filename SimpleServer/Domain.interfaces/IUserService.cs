using Entities;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        User AddNewUser(User user);
    }
}