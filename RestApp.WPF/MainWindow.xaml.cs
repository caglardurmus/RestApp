using RestApp.Business.DependencyResolvers.Ninject;
using RestApp.DataAccess.Abstract;
using System;
using System.Collections.Generic;
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

namespace RestApp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
        //    InstanceFactory.GetInstance<ICategoryDal>().AddDefaultCategories();
        //    InstanceFactory.GetInstance<IProductDal>().AddDefaultProduts();
        //    InstanceFactory.GetInstance<ISubCategoryDal>().AddDefaultSubCategories();



            InitializeComponent();
            var categories = InstanceFactory.GetInstance<ICategoryDal>().GetAll();
            var count = 0;
            foreach (var item in categories)
            {
                this.gridButtons.ColumnDefinitions.Add(new ColumnDefinition());
                var btn = new RadioButton();
                btn.Name = "category_" + item.Id;
                btn.Content = item.CategoryName;
                btn.Click += categoryBtn_Click;
                Grid.SetColumn(btn, count);
                this.gridButtons.Children.Add(btn);
                count++;
            }
        }

        private void categoryBtn_Click(object sender, RoutedEventArgs e)
        { 
            RadioButton button = (RadioButton)sender;
            var id = button.Name.Replace("category_", "");
            var subCategories = InstanceFactory.GetInstance<ISubCategoryDal>().GetAll(x => x.CategoryId == Convert.ToInt32(id));
            this.gridButtonsSub.ColumnDefinitions.Clear();
            var count = 0;
            foreach (var item in subCategories)
            {
                this.gridButtonsSub.ColumnDefinitions.Add(new ColumnDefinition());
                var btn = new RadioButton();
                btn.Name = "subcategory_" + item.Id;
                btn.Content = item.SubCategoryName;
                btn.Click += subCategoryBtn_Click;
                Grid.SetColumn(btn, count);
                this.gridButtonsSub.Children.Add(btn);
                count++;
            }
        }

        private void subCategoryBtn_Click(object sender, RoutedEventArgs e)
        {

            RadioButton button = (RadioButton)sender;
            var id = button.Name.Replace("subcategory_", "");
            var products = InstanceFactory.GetInstance<IProductDal>().GetAll(x => x.SubCategoryId == Convert.ToInt32(id));
            this.gridProducts.ColumnDefinitions.Clear();
            var count = 0;
            foreach (var item in products)
            {
                this.gridProducts.ColumnDefinitions.Add(new ColumnDefinition());
                var btn = new RadioButton();
                btn.Name = "product_" + item.Id;
                btn.Content = item.ProductName;
                btn.Click += subCategoryBtn_Click;
                Grid.SetColumn(btn, count);
                this.gridProducts.Children.Add(btn);
                count++;
            }
        }
    }
}
