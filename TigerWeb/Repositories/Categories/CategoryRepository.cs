using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using TigerWeb.Models;

namespace TigerWeb.Repositories.Categories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ConcurrentDictionary<int, Category> _storage = new ConcurrentDictionary<int, Category>();

        public Category GetSingle(int id)
        {
            Category category;
            return _storage.TryGetValue(id, out category) ? category : null;
        }

        public Category Add(Category item)
        {
            item.Id = !GetAll().Any() ? 1 : GetAll().Max(x => x.Id) + 1;

            if (_storage.TryAdd(item.Id, item))
            {
                return item;
            }

            throw new Exception("Item could not be added");
        }

        public void Delete(int id)
        {
            Category category;
            if (!_storage.TryRemove(id, out category))
            {
                throw new Exception("Item could not be removed");
            }
        }

        public Category Update(int id, Category item)
        {
            _storage.TryUpdate(id, item, GetSingle(id));
            return item;
        }

        public ICollection<Category> GetAll()
        {
            return _storage.Values;
        }

        public int Count()
        {
            return _storage.Count;
        }
    }
}
