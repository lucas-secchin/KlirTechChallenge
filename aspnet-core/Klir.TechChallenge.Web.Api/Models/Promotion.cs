using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api.Models
{
    public class Promotion
    {
        public enum PromotionType
        {
            BuyOneGetOneFree, ThreeForTenEuro
        };

        public int Id { get; set; }
        public string Name { get; set; }
        public PromotionType Type { get; set; }

        public static List<Promotion> PromotionList = 
            new List<Promotion>()
                {
                    new Promotion() {
                        Id = 1,
                        Name = "Buy 1 Get 1 Free",
                        Type = PromotionType.BuyOneGetOneFree
                    },
                    new Promotion() {
                        Id = 2,
                        Name = "3 for 10 Euro",
                        Type = PromotionType.ThreeForTenEuro
                    }
                };
    }
}
