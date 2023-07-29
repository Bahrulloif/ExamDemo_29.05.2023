using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private CategoryService _categoryService = new CategoryService();

    [HttpPost("Add")]
    public Category AddCategory(Category category)
    {
        return _categoryService.CreateCategory(category);
    }

[HttpGet("Read")]
public List<Category> ReadCategory()
{
    return _categoryService.GetCategories();
}


[HttpPost("Update")]

public int UpdateCategory(Category category)
{
    return _categoryService.UpdateCategory(category);
}


[HttpDelete("Delete")]
public int DeleteCategory(int id)
{
    return _categoryService.DeleteCategory(id);
}

}
