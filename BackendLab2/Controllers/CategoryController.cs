using BackendLab2.Models;
using BackendLab2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackendLab2.Controllers;

[ApiController]
public class CategoryController : ControllerBase
{
    private readonly CategoryRepository _repository;

    public CategoryController(CategoryRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("/category")]
    public async Task<ActionResult<List<Category>>> ListCategory()
    {
        try
        {
            var categories = await _repository.GetAllCategories();
            return Ok(categories);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("/category")]
    public async Task<ActionResult> PostCategory([FromBody] Category category)
    {
        try
        {
            var categoryId = await _repository.CreateNewCategory(category);
            return Created(
                $"/category/{categoryId}",
                new { id = categoryId }
            );
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("/category/{id:int}")]
    public async Task<ActionResult> DeleteCategory(int id)
    {
        try
        {
            await _repository.DeleteCategory(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}