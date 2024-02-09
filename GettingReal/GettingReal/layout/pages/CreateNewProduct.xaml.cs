using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for CreateNewProduct.xaml
    /// </summary>
    public partial class CreateNewProduct : Page
    {
        List<string> locations;

        ProductController controller;

        internal CreateNewProduct(ProductController controller)
        {
            InitializeComponent();
            locations = new List<string>();
            this.controller = controller;
        }

        

        private void AddProductHandler(object sender, RoutedEventArgs e)
        {
            bool success = true;

            StringBuilder sb = new StringBuilder();

            double test;

            List<string> errors = new List<string>();
            // DRY ( DO Repeat Yourself )
            if((ProductNumber.Text == null) || (ProductNumber.Text == ""))
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
            } else if (!Double.TryParse(ProductPrice.Text, out test))
            {
                errors.Add("Invalid Number");
                success = false;
                ProductPrice.Text = "";
            }

            if(locations.Count == 0)
            {
                errors.Add("No locations selected");
                success = false;
            }

            if (success)
            {
                controller.AddProduct(ProductNumber.Text, ProductDescription.Text, ProductPrice.Text, locations);
                ProductNumber.Text = "";
                ProductDescription.Text = "";
                ProductPrice.Text = "";

                locations.Clear();
                Locations.Items.Clear();
            }
            else
            {
                

                foreach(string s in errors)
                {
                    sb.AppendLine(String.Format("{0}\n", s));
                }

                // Communicate to user what errors were encountered
                MessageBox.Show(sb.ToString());
            }
        }

        private void AddLocation(object o, RoutedEventArgs e)
        {
            if(CurrentLocation.Text == null || CurrentLocation.Text == "")
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
            foreach(ListViewItem lvi in Locations.SelectedItems)
            {

                // Can't mutate the list being iterated in a foreach loop
                deletedItems.Add(lvi);

                // locations is the List<string> ( in the logic )
                locations.Remove(Convert.ToString(lvi.Content));
            }

            foreach(ListViewItem lvi in deletedItems)
            {
                // You can however do this

                // Locations is the ListView ( in the UI ) 
                Locations.Items.Remove(lvi);
            }
            
        }

        
    }
}
