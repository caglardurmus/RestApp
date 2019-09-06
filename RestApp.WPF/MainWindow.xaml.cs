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
            InitializeComponent();

            var categories = InstanceFactory.GetInstance<ICategoryDal>().GetAll();
            var count = 0;
            foreach (var item in categories)
            {
                this.gridButtons.ColumnDefinitions.Add(new ColumnDefinition());
                var btn = new RadioButton();
                btn.Name = item.CategoryName + item.Id;
                btn.Content = item.CategoryName;
                btn.Click += new RoutedEventHandler(btn_Click);
                Grid.SetColumn(btn, count);
                this.gridButtons.Children.Add(btn);
                count++;
            }


            void btn_Click(object sender, RoutedEventArgs e)
            {
                RadioButton button = (RadioButton)sender;
                LoadData(button.Content.ToString());
            }

            void LoadData(string str)
            {
                
            }
        }
    }
}
