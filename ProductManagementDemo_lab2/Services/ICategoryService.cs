using System.Collections.Generic;
using BusinessObjects;

namespace Services
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category? GetCategoryById(int id);
        Category CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);
    }
}
