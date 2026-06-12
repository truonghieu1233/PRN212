using CategoryRepo;
using CRUD_FPT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryService
{
    public class CateService
    {
        public CategoryRepository categoryRepo; 
        public CateService() 
        {
            categoryRepo = new CategoryRepository();
        }
        public List<Category> GetAllCategories()
        {
            return categoryRepo.GetAll();
        }
        public List<Category> InsertCategory(Category category)
        {
            categoryRepo.InsertCategory(category);
            return categoryRepo.GetAll();
        }
        public List<Category> UpdateCategory(Category category)
        {
            categoryRepo.UpdateCateGory(category);
            return categoryRepo.GetAll();
        }
        public List<Category> DeleteCategory(Category category)
        {
            categoryRepo.DeleteCategory(category);
            return categoryRepo.GetAll();
        }
    }
}
