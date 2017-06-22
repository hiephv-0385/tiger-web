using System.Collections.Generic;

namespace Tiger.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Sort { get; set; }

        public List<Product> Products { get; set; }
    }
}
