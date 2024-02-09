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

namespace GettingReal.layout.components
{
    /// <summary>
    /// Interaction logic for ProductListingOrder.xaml
    /// </summary>
    public partial class ProductListingOrder : UserControl
    {
        public ProductListingOrder(string productNumber, int productAmount)
        {

            InitializeComponent();
            ProductAmount.Text = Convert.ToString(productAmount);
            ProductNumber.Text = Convert.ToString(productNumber);

        }
    }
}
