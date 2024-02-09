using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GettingReal.layout.pages
{
    /// <summary>
    /// Interaction logic for ProductOverview.xaml
    /// </summary>
    public partial class ProductOverview : Page
    {

        string headerID = "ItemId";
        ProductOverviewController controller;

        internal ProductOverview(ProductOverviewController controller)
        {

            InitializeComponent();

            layout.components.ProductListing header = new layout.components.ProductListing(headerID, "Amount", "Price", -1);
            ProductHeaders.Children.Add(header);

            this.controller = controller;
        }

        // dummy constructor
        public ProductOverview()
        {
            InitializeComponent();
        }

        public void AddProductToView(layout.components.ProductListing productListing)
        {
            ProductListings.Children.Add(productListing);

            // Add click listener for ProductListing in Overview
            productListing.MouseLeftButtonDown += OpenProduct;
        }

        public void OpenProduct(object o, RoutedEventArgs e)
        {
            string? itemId = Convert.ToString(((components.ProductListing)o).Resources["ItemId"]);
            if (itemId != headerID && itemId != null)
            {
                // If you don't click header, so an actual product
                controller.SelectProduct(itemId);
            }
        }

        internal void UpdateProduct(string itemId, Product product)
        {
            foreach(components.ProductListing productListing in ProductListings.Children)
            {
                if (productListing.ItemId.Text == itemId)
                {
                    productListing.Amount.Text = Convert.ToString(product.Amount);
                    productListing.Price.Text = Convert.ToString(product.Price);
                }
            }
        }


    }
}
