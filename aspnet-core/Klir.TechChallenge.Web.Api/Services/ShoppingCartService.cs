using Klir.TechChallenge.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api.Services
{
    public class ShoppingCartService
    {
        public List<ShoppingCartItem> CalculateCheckout(List<ShoppingCartItem> shoppingCartList)
        {
            PromotionService promotionService = new PromotionService();
            foreach (ShoppingCartItem item in shoppingCartList)
            {
                promotionService.CalulateAndSetPromotion(item);
            }

            return shoppingCartList;
        }
    }
}
