using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApp.WPF.Models
{
    public class Cart
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }
        public List<CartItem> CartItems { get; set; }
        public int CountItems
        {
            get
            {
                return CartItems.Sum(x => x.Quantity);
            }
        }
        public decimal Total
        {
            get { return CartItems.Sum(x => x.Product.Price * x.Quantity); }
        }

    }
}
