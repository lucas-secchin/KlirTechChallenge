using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> Items { set; get; }
        public virtual decimal TotalPrice => Items.Sum(x => x.TotalPrice);
    }

    public class ShoppingCartItem
    {
        public Product Product { set; get; }
        public int Quantity { set; get; }
        public decimal TotalPrice { set; get; }
        public bool PromotionApplied { set; get; }
    }
}
