using LopushokApp.ADO;
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

namespace LopushokApp.Pages
{
    /// <summary>
    /// Interaction logic for ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        private List<Product> _products = new List<Product>();

        public ProductListPage()
        {
            InitializeComponent(); 
            _products = App.Connection.Product.ToList();
            lvProducts.ItemsSource = _products;
        }

        private void Search()
        {
            try
            {
                lvProducts.ItemsSource = _products
                    .Where(x => string.Join(" ", x.Name).ToLower().Contains(tbSearch.Text.ToLower()));
            }
            catch { }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }
    }
}
