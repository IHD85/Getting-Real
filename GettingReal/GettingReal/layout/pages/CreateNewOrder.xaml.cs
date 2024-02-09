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
    /// Interaction logic for CreateNewOrder.xaml
    /// </summary>
    public partial class CreateNewOrder : Page
    {

        List<string> products;
        OrderController controller;

        internal CreateNewOrder(OrderController orderController)
        {
            InitializeComponent();
            products = new List<string>();
            controller = orderController;
        }


        private void RemoveProduct(object o, RoutedEventArgs e)
        {
         
        }


        private void AddProduct(object o, RoutedEventArgs e)
        {
            if (CurrentProduct.Text == null || CurrentProduct.Text == "")
            {
                MessageBox.Show("No input for location");
                return;
            }
            int count = controller.GetProductAmount(CurrentProduct.Text);
            if (count == -1)
            {
                MessageBox.Show("Product doesnt exist");
                return;
            }
            if(Convert.ToDouble(Amount.Text)<= 0)
            {
                MessageBox.Show("Can't order zero or less products.");
                return;
            }
            
        }

        
    }
}
