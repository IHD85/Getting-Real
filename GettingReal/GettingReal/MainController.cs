using GettingReal.layout;
using GettingReal.layout.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GettingReal
{
    internal class MainController
    {
        ProductOverviewController poc;
        ProductController pc;
        OrderController oc;
        

        ProductRepository productRepository;
        OrderRepository orderRepository;

        layout.pages.ProductOverview productOverview;
        layout.pages.CreateNewProduct createNewProduct;
        layout.pages.EditProduct editProduct;
        layout.pages.CreateNewOrder createNewOrder;
        layout.pages.OrderOverview orderOverview;

        Frame frame;

        public MainController()
        {
            productRepository = new ProductRepository();
            orderRepository = new OrderRepository();
            
            poc = new ProductOverviewController(productRepository,this);
            pc = new ProductController(productRepository,this);
            oc = new OrderController(orderRepository,productRepository,this);

            productOverview = new layout.pages.ProductOverview(poc);
            createNewProduct = new layout.pages.CreateNewProduct(pc);
            editProduct = new layout.pages.EditProduct(pc);
            createNewOrder = new CreateNewOrder(oc);
        }

        public void SetFrame(Frame frame)
        {
            this.frame = frame;
        }

        public void AddProductToViewstring(string itemId, string amount, string price, int count)
        {
            layout.components.ProductListing productListing = new layout.components.ProductListing(itemId, amount, price, count); ;
            productOverview.AddProductToView(productListing);
        }

        public void EditProduct(Product product)
        {
            editProduct.SetProduct(product);
            frame.DataContext = editProduct;
        }

        public layout.pages.CreateNewProduct CreateNewProduct()
        {
            return createNewProduct;
        }

        public layout.pages.ProductOverview ProductOverview()
        {
            return productOverview;
        }

        public layout.pages.CreateNewOrder CreateNewOrder()
        {
            return createNewOrder;
        }

        public layout.pages.OrderOverview OrderOverveiw()
        {
            return orderOverview;
        }


        public void UpdateProduct(string itemId, Product product)
        {
            foreach(layout.components.ProductListing pl in productOverview.ProductListings.Children)
            {
                if(pl.ItemId.Text == itemId)
                {
                    pl.Amount.Text = Convert.ToString(product.Amount);
                    pl.Price.Text = Convert.ToString(product.Price);
                }
            }
        }
       
    }
}
