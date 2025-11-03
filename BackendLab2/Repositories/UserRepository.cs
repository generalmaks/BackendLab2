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

    public Task<int> CreateUser(User user)
    {
        var userId = DatabaseSubstitute.Users.Count > 0
            ? DatabaseSubstitute.Users.Max(u => u.Id) + 1
            : 1;
        DatabaseSubstitute.Users.Add(user);
        return Task.FromResult(userId);
    }

    public Task<List<User>> GetAllUsers()
    {
        return Task.FromResult(DatabaseSubstitute.Users);
    }
}