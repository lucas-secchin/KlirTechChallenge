using Klir.TechChallenge.Web.Api.Models;
using Klir.TechChallenge.Web.Api.Services;
using System;
using Xunit;


namespace Klir.TechChallenge.Tests.Tests
{
    public class CheckoutShoppingCartTest
    {
        private ShoppingCartItem itemBuyOneGetOneFree = new ShoppingCartItem()
        {
            Product = new Product()
            {
                CurrentPromotion = new Promotion()
                {
                    Type = Promotion.PromotionType.BuyOneGetOneFree
                },
                Price = 20
            }
        };

        private ShoppingCartItem itemThreeForTenEuro = new ShoppingCartItem()
        {
            Product = new Product()
            {
                CurrentPromotion = new Promotion()
                {
                    Type = Promotion.PromotionType.ThreeForTenEuro
                },
                Price = 4
            }
        };

        #region THEORY
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Theory_Promotion_BuyOneGetOneFree(int quantity)
        {
            PromotionService service = new PromotionService();

            itemBuyOneGetOneFree.Quantity = quantity;
            service.CalulateAndSetPromotion(itemBuyOneGetOneFree);
            
            Assert.Equal(itemBuyOneGetOneFree.PromotionApplied, quantity >= 2);

            int div = itemBuyOneGetOneFree.Quantity / 2;
            int divRem = itemBuyOneGetOneFree.Quantity % 2;
            decimal totalPrice = (div * itemBuyOneGetOneFree.Product.Price) + (divRem * itemBuyOneGetOneFree.Product.Price);
          
            Assert.Equal(totalPrice, itemBuyOneGetOneFree.TotalPrice);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(6)]
        public void Theory_Promotion_ThreeForTenEuro(int quantity)
        {
            PromotionService service = new PromotionService();

            itemThreeForTenEuro.Quantity = quantity;
            service.CalulateAndSetPromotion(itemThreeForTenEuro);

            Assert.Equal(itemThreeForTenEuro.PromotionApplied, quantity >= 3);

            int div = itemThreeForTenEuro.Quantity / 3;
            int divRem = itemThreeForTenEuro.Quantity % 3;
            decimal totalPrice = (div * 10) + (divRem * itemThreeForTenEuro.Product.Price);

            Assert.Equal(totalPrice, itemThreeForTenEuro.TotalPrice);
        }
        #endregion
        #region FACT
        [Fact]
        public void Fact_Promotion_BuyOneGetOneFree_Random()
        {
            PromotionService service = new PromotionService();

            Random rand = new Random();
            for (int i=0; i<10; i++)
            {
                itemBuyOneGetOneFree.Quantity = rand.Next();
                service.CalulateAndSetPromotion(itemBuyOneGetOneFree);

                int div = itemBuyOneGetOneFree.Quantity / 2;
                int divRem = itemBuyOneGetOneFree.Quantity % 2;
                
                bool promotionApplied = div > 0;
                decimal totalPrice = (div * itemBuyOneGetOneFree.Product.Price) + (divRem * itemBuyOneGetOneFree.Product.Price);

                Assert.Equal(promotionApplied, itemBuyOneGetOneFree.PromotionApplied);
                Assert.Equal(totalPrice, itemBuyOneGetOneFree.TotalPrice);
            }
        }

        [Fact]
        public void Fact_Promotion_ThreeForTenEuro_Random()
        {
            PromotionService service = new PromotionService();

            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                itemThreeForTenEuro.Quantity = rand.Next();
                service.CalulateAndSetPromotion(itemThreeForTenEuro);

                int div = itemThreeForTenEuro.Quantity / 3;
                int divRem = itemThreeForTenEuro.Quantity % 3;
                bool promotionApplied = div > 0;
                decimal totalPrice = (div * 10) + (divRem * itemThreeForTenEuro.Product.Price);

                Assert.Equal(promotionApplied, itemThreeForTenEuro.PromotionApplied);
                Assert.Equal(totalPrice, itemThreeForTenEuro.TotalPrice);
            }
        }
        #endregion
    }
}
