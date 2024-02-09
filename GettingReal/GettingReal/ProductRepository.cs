using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    internal class ProductRepository
    {
        private List<Product> products;

        public ProductRepository()
        {
            products = new List<Product>();

        }

        public void AddProduct(Product product)
        {
            // TODO : Don't allow duplicate itemIds

            products.Add(product);
        }

        public void RemoveProduct(string itemId) { }

        public List<Product> GetAllProducts() { 
            return products;
        }

        public Product? GetProduct(string itemId) {
            foreach(Product product in products)
            {
                if (product.ItemId == itemId)
                    return product;
            } 
            return null;  
        }

    }
}
