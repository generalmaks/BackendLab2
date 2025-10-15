using BackendLab2.Database;
using BackendLab2.Models;

namespace BackendLab2.Repositories;

public class UserRepository
{
    public Task<User?> GetUser(int id)
    {
        return Task.FromResult(DatabaseSubstitute.Users.FirstOrDefault(u => u.Id == id));
    }

    public Task DeleteUser(int id)
    {
        var index = DatabaseSubstitute.Users.FindIndex(u => u.Id == id);
        DatabaseSubstitute.Users.RemoveAt(index);

        return Task.CompletedTask;
    }

    public Task CreateUser(User user)
    {
        DatabaseSubstitute.Users.Add(user);
        return Task.CompletedTask;
    }

    public Task<List<User>> GetAllUsers()
    {
        return Task.FromResult(DatabaseSubstitute.Users);
    }
}