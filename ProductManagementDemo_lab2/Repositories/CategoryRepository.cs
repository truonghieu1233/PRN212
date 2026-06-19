using System.Collections.Generic;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<Category> GetCategories()
        {
            return CategoryDAO.Instance.GetCategories();
        }

        public Category? GetCategoryById(int id)
        {
            return CategoryDAO.Instance.GetCategoryById(id);
        }

        public Category CreateCategory(Category category)
        {
            return CategoryDAO.Instance.CreateCategory(category);
        }

        public bool UpdateCategory(Category category)
        {
            return CategoryDAO.Instance.UpdateCategory(category);
        }

        public bool DeleteCategory(int id)
        {
            return CategoryDAO.Instance.DeleteCategory(id);
        }
    }
}
