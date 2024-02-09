using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    internal class OrderController
    {
        MainController controller;
        OrderRepository orderRepo;
        ProductRepository productRepo;

        public OrderController(OrderRepository orderRepository, ProductRepository productRepository, MainController mainController)
        {
            orderRepo = orderRepository;
            productRepo = productRepository;
            controller = mainController;
        }

        public int GetProductAmount(string itemId)
        {
            Product product = productRepo.GetProduct(itemId);
            if(product == null)
            {
                return -1;
            }
            return product.Amount;
        }

    }
}
