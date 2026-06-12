using CRUD_FPT.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CategoryRepo
{
    public class CategoryRepository
    {
        public MyStoreContext myStoreContext;
        public CategoryRepository()
        {
            myStoreContext = new MyStoreContext();
            myStoreContext.Database.EnsureCreated();
        }
        public List<Category> GetAll()
        {
            return myStoreContext.Categories.ToList();
        }
        public Category? GetById(int id)
        {
            return myStoreContext.Categories.Find(id);
        }
        public void InsertCategory(Category category)
        {
            myStoreContext.Categories.Add(category);
            myStoreContext.SaveChanges();
        }
        public void UpdateCateGory(Category category)
        {
            // Ép EF Core theo dõi và cập nhật trạng thái của đối tượng này thành Modified
            myStoreContext.Categories.Update(category);

            // Lưu thay đổi vào SQL Server
            myStoreContext.SaveChanges();
        }
        public void DeleteCategory(Category category)
        {
            myStoreContext.Categories.Remove(category);
            myStoreContext.SaveChanges();
        }
    }
}
