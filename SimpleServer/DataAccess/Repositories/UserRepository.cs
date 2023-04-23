using DataAccess.Interfaces;
using Entities;
using Entities.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly DbContext _dbContext;
        
        public UserRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User AddUser(User newUser)
        {
            try
            {
                _dbContext.Set<User>().Add(newUser);
                _dbContext.SaveChanges();
                return newUser;

            }
            catch (SqlException s)
            {
                throw new QueryException(s);
            }
            catch (Exception ex)
            {
                throw new UnexpectedDataAccessException(ex);
            }
        }

        public User Get(Func<User, bool> func)
        {
            try
            {
                var user = _dbContext.Set<User>().FirstOrDefault(func);
                return user;
            }
            catch (SqlException s)
            {
                throw new QueryException(s);
            }
            catch (Exception ex)
            {
                throw new UnexpectedDataAccessException(ex);
            }
        }

        public bool Exist(Func<User, bool> func)
        {
            try
            {
                return _dbContext.Set<User>().Any(func);
            }
            catch (SqlException s)
            {
                throw new QueryException(s);
            }
            catch (Exception ex)
            {
                throw new UnexpectedDataAccessException(ex);
            }
        }
    }
}
