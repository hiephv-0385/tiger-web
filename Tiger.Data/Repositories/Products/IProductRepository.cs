using System.Collections.Generic;
using Tiger.Data.Entities;

namespace Tiger.Data.Repositories.Products
{
    public interface IProductRepository
    {
        Product GetSingle(int id);
        Product Add(Product item);
        void Delete(int id);
        Product Update(int id, Product item);
        ICollection<Product> GetAll();
        int Count();
    }
}
