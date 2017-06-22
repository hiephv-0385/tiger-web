using System.Collections.Generic;
using Tiger.Data.Entities;

namespace Tiger.Data.Repositories.Categories
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
