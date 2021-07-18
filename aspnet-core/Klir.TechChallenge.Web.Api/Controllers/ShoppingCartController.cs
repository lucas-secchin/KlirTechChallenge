using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Klir.TechChallenge.Web.Api.DTOs;
using Klir.TechChallenge.Web.Api.Models;
using Klir.TechChallenge.Web.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Klir.TechChallenge.Web.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ILogger<ShoppingCartController> _logger;

        public ShoppingCartController(ILogger<ShoppingCartController> logger)
        {
            _logger = logger;
        }

        [HttpGet("checkout")]
        public ShoppingCart CalculateCheckout(List<ShoppingCartItem> shoppingCartList)
        {
            var checkoutService = new ShoppingCartService();

            var shoppingCartItemList = checkoutService.CalculateCheckout(shoppingCartList);
            
            return new ShoppingCart() { Items = shoppingCartItemList };
        }
    }
}