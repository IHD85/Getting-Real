using GettingReal.layout;
using GettingReal.layout.pages;
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

namespace GettingReal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainController controller;

        public MainWindow()
        {
            InitializeComponent();
            controller = new MainController();
            controller.SetFrame(ProductFrame);
        }
        

        private void CreateNewProduct(object o, RoutedEventArgs e)
        {
            if(controller == null)
            {
                controller = new MainController();
            }
            ProductFrame.DataContext = controller.CreateNewProduct();
        }

        private void ProductOverview(object o, RoutedEventArgs e)
        {
            if (controller == null)
            {
                controller = new MainController();
            }
            ProductFrame.DataContext = controller.ProductOverview();
        }

        private void OrderOverview(object o, RoutedEventArgs e)
        {
            if(controller == null)
            {
                controller = new MainController();
            }
            Trace.WriteLine("kffkfkfkkfz");
            ProductFrame.DataContext = controller.OrderOverveiw();
        }

        private void CreateOrder(object o, RoutedEventArgs e)
        {
            if (controller == null)
            {
                controller = new MainController();
            }
            Trace.WriteLine("hello");
            ProductFrame.DataContext = controller.CreateNewOrder();
        }


    }
}
