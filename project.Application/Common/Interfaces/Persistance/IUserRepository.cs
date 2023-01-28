using System;
using project.Domain.Entities;

namespace project.Application.Common.Interfaces.Persistance;

public interface IUserRepository
{
    User? GetUserByEmail(string email);

    void Add(User user);
}

