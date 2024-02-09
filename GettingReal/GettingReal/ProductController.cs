using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    internal partial class ProductController
    {
        ProductRepository productRepository;
        MainController controller;

        

        public ProductController(ProductRepository repo, MainController mainController)
        {
            productRepository = repo;
            controller = mainController;            
        }

        public void AddProduct(string itemId, string itemDescription, string priceText, List<string> locations)
        {
            double price = Convert.ToDouble(priceText);

            Product product = new Product(itemId, itemDescription, price);
            foreach (string location in locations)
                product.AddLocation(location);
            productRepository.AddProduct(product);
            int count = productRepository.GetAllProducts().Count;
            controller.AddProductToViewstring(itemId, "0", priceText, count);
        }

        public void EditProduct(string oldItemid, string itemId, string itemDescription, string priceText, List<string> locations, int amount)
        {
            
            Product product = productRepository.GetProduct(oldItemid);

            product.ItemId = itemId;
            product.ItemDescription = itemDescription;
            product.Price = Double.Parse(priceText);
            product.SetLocations(locations);
            product.Amount = amount;
            
        }

        public void UpdateProduct(string itemId, Product product)
        {
            controller.UpdateProduct(itemId,product);
        }
    }
}
