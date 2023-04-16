using DataAccess.Interfaces;
using Domain.Interfaces.Exceptions;
using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            catch(SqlException s) {
                throw new QueryException(s);
            }
            catch (Exception ex)
            {
                throw new UnexpectedDataAccessException(ex);
            }
        }
    }
}
