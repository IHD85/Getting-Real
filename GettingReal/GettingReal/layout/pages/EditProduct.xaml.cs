using System;
using System.Collections.Generic;
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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class EditProduct : Page
    {
     

        List<string> locations;

        ProductController controller;

        string oldItemID;

        internal EditProduct(ProductController controller)
        {
            InitializeComponent();
            locations = new List<string>();
            this.controller = controller;

        }

        // this is NOT very good

        internal void SetProduct(Product product)
        {
            if(oldItemID==null || oldItemID == "")
            {
                oldItemID = product.ItemId;
            }

            ProductNumber.Text = product.ItemId;
            ProductDescription.Text = product.ItemDescription;
            ProductPrice.Text = Convert.ToString(product.Price);
            ProductAmount.Text = Convert.ToString(product.Amount);

            Locations.Items.Clear();

            foreach(string location in product.GetLocations())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Content = location;

                Locations.Items.Add(lvi);

                locations.Add(location);
            }
        }


        private void EditProductHandler(object sender, RoutedEventArgs e)
        {
            bool success = true;

            StringBuilder sb = new StringBuilder();

            double test;

            List<string> errors = new List<string>();
            // DRY ( DO Repeat Yourself )
            if ((ProductNumber.Text == null) || (ProductNumber.Text == ""))
            {
                errors.Add("Empty Product Number");
                success = false;
                ProductNumber.Text = "";
            }

            if ((ProductDescription.Text == null) || (ProductDescription.Text == ""))
            {
                errors.Add("Empty Product Description");
                success = false;
                ProductDescription.Text = "";
            }

            if ((ProductPrice.Text == null) || (ProductPrice.Text == ""))
            {
                errors.Add("Empty Product Price");
                success = false;
                ProductPrice.Text = "";
            }
            else if (!Double.TryParse(ProductPrice.Text, out test))
            {
                errors.Add("Invalid Number");
                success = false;
                ProductPrice.Text = "";
            }

            if (locations.Count == 0)
            {
                errors.Add("No locations selected");
                success = false;
            }

            if (success)
            {
                int amount = Convert.ToInt32(ProductAmount.Text);
                controller.EditProduct(oldItemID, ProductNumber.Text, ProductDescription.Text, ProductPrice.Text, locations, amount);
                ProductNumber.Text = "";
                ProductDescription.Text = "";
                ProductPrice.Text = "";
                locations = new List<string>();

                Product product = new Product(ProductNumber.Text, ProductDescription.Text, Convert.ToDouble(ProductPrice.Text));

                controller.UpdateProduct(ProductNumber.Text, product);
            }
            else
            {


                foreach (string s in errors)
                {
                    sb.AppendLine(String.Format("{0}\n", s));
                }

                // Communicate to user what errors were encountered
                MessageBox.Show(sb.ToString());
            }
        }

        private void AddLocation(object o, RoutedEventArgs e)
        {
            if (CurrentLocation.Text == null || CurrentLocation.Text == "")
            {
                MessageBox.Show("No input for location");
                return;
            }

            locations.Add(CurrentLocation.Text);
            ListViewItem listViewItem = new ListViewItem();
            listViewItem.Content = CurrentLocation.Text;

            Locations.Items.Add(listViewItem);
            CurrentLocation.Text = "";
        }

        private void RemoveLocation(object o, RoutedEventArgs e)
        {
            // TODO fix, IDE is unhappy
            List<ListViewItem> deletedItems = new List<ListViewItem>();
            foreach (ListViewItem lvi in Locations.SelectedItems)
            {

                // Can't mutate the list being iterated in a foreach loop
                deletedItems.Add(lvi);

                // locations is the List<string> ( in the logic )
                locations.Remove(Convert.ToString(lvi.Content));
            }

            foreach (ListViewItem lvi in deletedItems)
            {
                // You can however do this

                // Locations is the ListView ( in the UI ) 
                Locations.Items.Remove(lvi);
            }

        }
    }
}
