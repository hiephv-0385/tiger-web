using System.Collections.Generic;
using TigerWeb.Models;

namespace TigerWeb.Repositories.Categories
{
    public interface ICategoryRepository
    {
        Category GetSingle(int id);
        Category Add(Category item);
        void Delete(int id);
        Category Update(int id, Category item);
        ICollection<Category> GetAll();
        int Count();
    }
}
