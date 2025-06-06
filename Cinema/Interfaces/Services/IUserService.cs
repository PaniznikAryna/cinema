﻿using Cinema.Entity;

namespace Cinema.Interfaces.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User? GetById(int id);
        User Add(User user);
        void Update(User user);
        void Delete(int id);
    }
}
