﻿using Domain.Interfaces;
using Entities;
using DataAccess.Interfaces;

namespace Domain
{
    public class UserService:IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User AddNewUser(User user)
        {
            user.Validate();
            return userRepository.AddUser(user);
        }
    }
}