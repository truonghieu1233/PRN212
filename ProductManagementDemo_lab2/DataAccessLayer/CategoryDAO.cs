using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;

namespace DataAccessLayer
{
    public class CategoryDAO
    {
        private static CategoryDAO? instance;
        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null) instance = new CategoryDAO();
                return instance;
            }
        }

        public List<Category> GetCategories()
        {
            using var context = new MyStoreContext();
            return context.Categories.ToList();
        }

        public Category? GetCategoryById(int id)
        {
            using var context = new MyStoreContext();
            return context.Categories.FirstOrDefault(c => c.CategoryId == id);
        }

        public Category CreateCategory(Category category)
        {
            using var context = new MyStoreContext();
            context.Categories.Add(category);
            context.SaveChanges();
            return category;
        }

        public bool UpdateCategory(Category category)
        {
            using var context = new MyStoreContext();
            var existing = context.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            if (existing == null) return false;

            existing.CategoryName = category.CategoryName;
            context.SaveChanges();
            return true;
        }

        public bool DeleteCategory(int id)
        {
            using var context = new MyStoreContext();
            var existing = context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (existing == null) return false;

            context.Categories.Remove(existing);
            context.SaveChanges();
            return true;
        }
    }
}
