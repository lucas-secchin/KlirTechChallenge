using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Promotion CurrentPromotion { get; set; }

        public static List<Product> ProductList = new List<Product>()
                {
                    new Product() {
                        Id = 1,
                        Name = "PRODUCT A",
                        Price = 20,
                        CurrentPromotion = Promotion.PromotionList.Where(x => x.Type == Promotion.PromotionType.BuyOneGetOneFree).FirstOrDefault()
                    },
                    new Product() {
                        Id = 2,
                        Name = "PRODUCT B",
                        Price = 4,
                        CurrentPromotion = Promotion.PromotionList.Where(x => x.Type == Promotion.PromotionType.ThreeForTenEuro).FirstOrDefault()
                    },
                    new Product() {
                        Id = 3,
                        Name = "PRODUCT C",
                        Price = 2,
                        CurrentPromotion = null
                    },
                    new Product() {
                        Id = 4,
                        Name = "PRODUCT D",
                        Price = 4,
                        CurrentPromotion = Promotion.PromotionList.Where(x => x.Type == Promotion.PromotionType.ThreeForTenEuro).FirstOrDefault()
                    },
                };
    }
}
