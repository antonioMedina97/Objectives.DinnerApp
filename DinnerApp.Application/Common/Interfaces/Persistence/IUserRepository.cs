using DinnerApp.Domain.Entities;

namespace DinnerApp.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}