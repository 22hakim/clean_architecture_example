using System;
using project.Domain.Entities;
using project.Application.Common.Interfaces.Persistance;

namespace project.Infra.Persistence
{
	public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(user => user.Email == email);
        }
    }
}

