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

namespace GettingReal.layout.components
{
    /// <summary>
    /// Interaction logic for ProductListing.xaml
    /// </summary>
    public partial class ProductListing : UserControl
    {
        public ProductListing(string itemId, string amount, string price, int count)
        {
            Brush c = (count % 2 == 0) ? Brushes.LightGray : Brushes.Moccasin;

            if (count == -1)
                c = Brushes.White;
            Trace.WriteLine(String.Format("{0}\n{1}\n{2}",itemId,amount,price));
            InitializeComponent();
            ItemId.Text = itemId;
            Amount.Text = Convert.ToString(amount);
            Price.Text = price;

            this.Background = c;
            this.Resources["ItemId"] = itemId;
        }
    }
}
