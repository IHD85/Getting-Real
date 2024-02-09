using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GettingReal
{
    internal class ProductOverviewController
    {

        MainController controller;
        ProductRepository repo;

        public ProductOverviewController(ProductRepository productRepository, MainController mainController)
        {
            controller = mainController;
            repo = productRepository;
        }

        public void InitializeOverview(Grid Parent, ProductRepository ProductRepository)
        {
            foreach(Product product in ProductRepository.GetAllProducts())
            {
                // Init of pre-written data goes here
            }
        }

        public void SelectProduct(string ItemId)
        {
            Product prod = repo.GetProduct(ItemId);
            controller.EditProduct(prod);
        }

    }
}
