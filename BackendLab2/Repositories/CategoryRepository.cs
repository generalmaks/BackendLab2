using BackendLab2.Database;
using BackendLab2.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendLab2.Repositories;

public class CategoryRepository
{
    public Task<List<Category>> GetAllCategories()
    {
        return Task.FromResult(DatabaseSubstitute.Categories);
    }

    public Task CreateNewCategory([FromBody] Category category)
    {
        DatabaseSubstitute.Categories.Add(category);
        return Task.CompletedTask;
    }

    public Task DeleteCategory(int id)
    {
        var index = DatabaseSubstitute.Categories.FindIndex(c => c.Id == id);
        DatabaseSubstitute.Categories.RemoveAt(index);
        return Task.CompletedTask;
    }
}