using Entities;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        User AddNewUser(User user);
        User GetUserByToken(Guid aToken);
        bool IsValidToken(Guid aToken);
    }
}