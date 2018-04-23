using DevExpress.Data.Linq;
using System;
using System.Windows;

namespace DXGrid_EF4_ServerMode {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            //You can use this demo code to generate a large data set, if currently, you don't have a large database for testing.
            NorthwindEntities dataContext = new NorthwindEntities();
            try {
                for (int i = 0; i < 100000; i++) {
                    Product product = new Product {
                        ProductName = string.Format("Product({0})", i),
                        UnitPrice = new Random().Next(1000),
                    };
                    dataContext.Products.AddObject(product);
                }
                dataContext.SaveChanges();
            }
            catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
            grid.ItemsSource = new EntityServerModeSource() {
                ElementType = typeof(Product),
                KeyExpression = "ProductID",
                QueryableSource = dataContext.Products
            };
        }
    }
}