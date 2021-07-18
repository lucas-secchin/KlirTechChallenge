using Klir.TechChallenge.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api.Services
{
    public class PromotionService
    {
        public ShoppingCartItem CalulateAndSetPromotion(ShoppingCartItem item)
        {
            if (item.Product.CurrentPromotion == null)
            {
                item.TotalPrice = item.Product.Price * item.Quantity;
            }
            else
            {
                int div;
                int divRem;
                switch (item.Product.CurrentPromotion.Type)
                {
                    case Promotion.PromotionType.BuyOneGetOneFree:
                        div = item.Quantity / 2;
                        divRem = item.Quantity % 2;
                        item.PromotionApplied = div > 0;
                        item.TotalPrice = (div * item.Product.Price) + (divRem * item.Product.Price);

                        break;
                    case Promotion.PromotionType.ThreeForTenEuro:
                        div = item.Quantity / 3;
                        divRem = item.Quantity % 3;
                        item.PromotionApplied = div > 0;
                        item.TotalPrice = (div * 10) + (divRem * item.Product.Price);

                        break;
                    default:
                        throw new Exception($"Promotion not found at product {item.Product.Name}.");
                }
            }

            return item;
        }
    }
}
