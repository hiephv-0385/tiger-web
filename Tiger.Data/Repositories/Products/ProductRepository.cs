using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tiger.Data.Entities;

namespace Tiger.Data.Repositories.Products
{
    public class ProductRepository: IProductRepository
    {
        private readonly TigerContext _tigerContext;

        public ProductRepository(TigerContext tigerContext)
        {
            _tigerContext = tigerContext;
        }

        public Product GetSingle(int id)
        {
            return _tigerContext.Products.Find(id);
        }

        public Product Add(Product item)
        {
            _tigerContext.Products.Add(item);
            _tigerContext.SaveChanges();

            return item;
        }

        public void Delete(int id)
        {
            Product product = _tigerContext.Products.Find(id);
            if (product == null)
            {
                throw new Exception("Item could not be removed");
            }
            _tigerContext.Products.Remove(product);
            _tigerContext.SaveChanges();
        }

        public Product Update(int id, Product item)
        {
            Product product = _tigerContext.Products.Find(id);
            if (product == null)
            {
                throw new Exception("Item could not be removed");
            }
            product.Name = item.Name;
            product.CategoryId = item.CategoryId;
            _tigerContext.Products.Update(product);
            _tigerContext.SaveChanges();

            return item;
        }

        public ICollection<Product> GetAll()
        {
            return _tigerContext.Products.ToList();
        }

        public int Count()
        {
            return _tigerContext.Products.Count();
        }
    }
}
