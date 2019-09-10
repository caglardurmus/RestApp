using RestApp.Business.DependencyResolvers.Ninject;
using RestApp.DataAccess.Abstract;
using RestApp.Entities.Concrete;
using RestApp.WPF.Models;
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
    public partial class MainWindow : Window
    {
        public Cart Cart;
        public List<CartItem> CartItems;
        public IProductDal ProductDal;
        public ICategoryDal CategoryDal;
        public ISubCategoryDal SubCategoryDal;

        public MainWindow()
        {

            InitializeComponent();
            this.ProductDal = InstanceFactory.GetInstance<IProductDal>();
            this.CategoryDal = InstanceFactory.GetInstance<ICategoryDal>();
            this.SubCategoryDal = InstanceFactory.GetInstance<ISubCategoryDal>();


            var categories = CategoryDal.GetAll();
            if (categories.Count == 0)
            {
                this.AddDefaults();
                categories = CategoryDal.GetAll();
            }

            var count = 0;
            foreach (var item in categories)
            {
                this.gridButtons.ColumnDefinitions.Add(new ColumnDefinition());
                var btn = new RadioButton()
                {
                    Name = "category_" + item.Id,
                    Content = item.CategoryName,
                };
                btn.Click += categoryBtn_Click;
                Grid.SetColumn(btn, count);
                this.gridButtons.Children.Add(btn);
                count++;
            }
            this.Cart = new Cart();

        }

        private void categoryBtn_Click(object sender, RoutedEventArgs e)
        {
            var button = (RadioButton)sender;
            var id = button.Name.Replace("category_", "");
            var subCategories = this.SubCategoryDal.GetAll(x => x.CategoryId == Convert.ToInt32(id));
            ClearGrid(gridButtonsSub);
            var count = 0;
            foreach (var item in subCategories)
            {
                this.gridButtonsSub.ColumnDefinitions.Add(new ColumnDefinition());
                var btn = new RadioButton()
                {
                    Name = "subcategory_" + item.Id,
                    Content = item.SubCategoryName
                };
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
            var products = this.ProductDal.GetAll(x => x.SubCategoryId == Convert.ToInt32(id));
            ClearGrid(gridProducts);
            RenderProducts(products);
        }

        private void RenderProducts(List<Product> products)
        {
            var rowCount = Math.Ceiling(Convert.ToDecimal(products.Count) / 5);

            for (int i = 0; i < rowCount; i++)
            {
                var row = new RowDefinition
                {
                    Height = new GridLength(100)
                };
                this.gridProducts.RowDefinitions.Add(row);
            }
            for (int i = 0; i < 5; i++)
            {
                this.gridProducts.ColumnDefinitions.Add(new ColumnDefinition());
            }

            var count = 0;
            var rowNumber = 0;
            foreach (var item in products)
            {
                if (count > 0 && count % 5 == 0)
                {
                    count = 0;
                    rowNumber++;
                }
                var grid = new Grid();
                grid.Height = 90;
                grid.Width = 160;
                grid.Children.Add(new TextBlock
                {
                    Text = item.ProductName,
                    VerticalAlignment = VerticalAlignment.Top

                });
                grid.Children.Add(new TextBlock
                {
                    Text = "€" + item.Price.ToString("0.00"),
                    VerticalAlignment = VerticalAlignment.Bottom

                });
                var btn = new Button
                {
                    Name = "product_" + item.Id,
                    Content = grid,
                };
                btn.Click += product_Click;
                Grid.SetColumn(btn, count);
                Grid.SetRow(btn, rowNumber);
                this.gridProducts.Children.Add(btn);
                count++;
            }
        }

        private void product_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var id = btn.Name.Replace("product_", "");
            var product = this.ProductDal.GetById(Convert.ToInt32(id));

            var productInCart = this.Cart.CartItems.FirstOrDefault(x => x.Product.Id == product.Id);
            if (productInCart != null)
            {
                productInCart.Quantity++;
            }
            else
            {
                var cartItem = new CartItem()
                {
                    Product = product,
                    Quantity = 1
                };
                this.Cart.CartItems.Add(cartItem);
            }
            LoadCartItems();

        }

        private void ClearGrid(Grid grid)
        {
            grid.Children.Clear();
            grid.ColumnDefinitions.Clear();
            grid.RowDefinitions.Clear();
        }

        private void LoadCartItems()
        {
            this.gridCartItems.Children.Clear();
            var count = 0;
            foreach (var item in this.Cart.CartItems)
            {
                var row = new RowDefinition
                {
                    Height = new GridLength(40),
                };
                this.gridCartItems.RowDefinitions.Add(row);
                var txtName = new TextBlock()
                {
                    Text = item.Product.ProductName,
                    FontSize = 15
                };
                var txtQuantity = new TextBlock()
                {
                    Text = item.Quantity.ToString(),
                    FontSize = 15
                };
                var txtProductPrice = new TextBlock()
                {
                    Text = item.Product.Price.ToString("0.00"),
                    FontSize = 15
                };
                var txtTotalPrice = new TextBlock()
                {
                    Text = item.CartItemPrice.ToString("0.00"),
                    FontSize = 15
                };
                Grid.SetColumn(txtName, 0);
                Grid.SetColumn(txtQuantity, 1);
                Grid.SetColumn(txtProductPrice, 2);
                Grid.SetColumn(txtTotalPrice, 3);
                Grid.SetRow(txtName, count);
                Grid.SetRow(txtProductPrice, count);
                Grid.SetRow(txtQuantity, count);
                Grid.SetRow(txtTotalPrice, count);

                this.gridCartItems.Children.Add(txtName);
                this.gridCartItems.Children.Add(txtProductPrice);
                this.gridCartItems.Children.Add(txtQuantity);
                this.gridCartItems.Children.Add(txtTotalPrice);
                count++;
            }
            LoadCart();
        }

        private void LoadCart()
        {
            this.gridCart.Children.Clear();
            var lblTotal = new TextBlock()
            {
                FontSize = 15,
                Text = "Total",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 0, 0, 0)
            };
            var total = new TextBlock()
            {
                FontSize = 15,
                Text = this.Cart.Total.ToString("€0.00"),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(10, 0, 0, 0)
            };
            var lblItems = new TextBlock()
            {
                FontSize = 15,
                Text = "Items",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 0, 0, 0)
            };
            var items = new TextBlock()
            {
                FontSize = 15,
                Text = this.Cart.CountItems.ToString(),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Right
            };
            Grid.SetColumn(lblItems, 0);
            Grid.SetColumn(items, 1);
            Grid.SetColumn(lblTotal, 2);
            Grid.SetColumn(total, 3);
            this.gridCart.Children.Add(lblItems);
            this.gridCart.Children.Add(items);
            this.gridCart.Children.Add(lblTotal);
            this.gridCart.Children.Add(total);

        }

        private void AddDefaults()
        {
            this.CategoryDal.AddDefaultCategories();
            this.SubCategoryDal.AddDefaultSubCategories();
            this.ProductDal.AddDefaultProduts();
        }
    }

}
