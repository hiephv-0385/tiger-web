using System;
using System.Collections.Generic;
using System.Linq;
using Tiger.Data.Entities;

namespace Tiger.Data.Repositories.Categories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly TigerContext _tigerContext;

        public CategoryRepository(TigerContext tigerContext)
        {
            _tigerContext = tigerContext;
        }

        public Category GetSingle(int id)
        {
            return _tigerContext.Categories.Find(id);
        }

        public Category Add(Category item)
        {
            _tigerContext.Categories.Add(item);
            _tigerContext.SaveChanges();

            return item;
        }

        public void Delete(int id)
        {
            Category category = _tigerContext.Categories.Find(id);
            if (category == null)
            {
                throw new Exception("Item could not be removed");
            }
            _tigerContext.Categories.Remove(category);
            _tigerContext.SaveChanges();
        }

        public Category Update(int id, Category item)
        {
            _tigerContext.Categories.Update(item);
            _tigerContext.SaveChanges();

            return item;
        }

        public ICollection<Category> GetAll()
        {
            return _tigerContext.Categories.ToList();
        }

        public int Count()
        {
            return _tigerContext.Categories.Count();
        }
    }
}
