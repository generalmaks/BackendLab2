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

    public Task<int> CreateNewCategory([FromBody] Category category)
    {
        var categoryId = DatabaseSubstitute.Categories.Count > 0 ?
            DatabaseSubstitute.Categories.Max(c => c.Id) + 1 : 1;
        DatabaseSubstitute.Categories.Add(category);
        return Task.FromResult(categoryId);
    }

    public Task DeleteCategory(int id)
    {
        var index = DatabaseSubstitute.Categories.FindIndex(c => c.Id == id);
        DatabaseSubstitute.Categories.RemoveAt(index);
        return Task.CompletedTask;
    }
}