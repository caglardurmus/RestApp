using RestApp.Business.DependencyResolvers.Ninject;
using RestApp.DataAccess.Abstract;
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

            this.comboBox.ItemsSource = categories;
            this.comboBox.DisplayMemberPath = "CategoryName";
            foreach (var item in categories)
            {
                this.gridButtons.RowDefinitions.Add(new RowDefinition());
            }
            foreach (var item in categories)
            {
                var btn = new Button();
                btn.Content = item.CategoryName;
                //btn.Name = item.Id.ToString();
                
                this.gridButtons.Children.Add(btn);

            }
        }
    }
}
