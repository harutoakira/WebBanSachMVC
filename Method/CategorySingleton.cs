using Microsoft.EntityFrameworkCore;
using QuanLyThuVien.Data;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Method
{
    public sealed class CategorySingleton
    {
        
        public static CategorySingleton Instance { get; } = new CategorySingleton();
        public List<Category> categories { get; } = new List<Category>();
        CategorySingleton() { }
        public void Init(BookDBContext context)
        {
            if(categories.Count == 0) 
            {
                var items =  context.categories.ToList();
                foreach(var item in items) 
                {
                    categories.Add(item);
                }
            }
        }
        public void Update(BookDBContext context)
        {
            categories.Clear();
            Init(context);
        }
    }
}
