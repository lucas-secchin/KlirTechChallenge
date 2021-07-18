using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ProductDTO> Get()
        {
            var productService = new ProductService();
            var productList = productService.GetAllAvailableProducts();            
            var productDTOList = new List<ProductDTO>();
            foreach (Product product in productList)
                productDTOList.Add(new ProductDTO()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    PromotionName = product.CurrentPromotion == null ? "" : product.CurrentPromotion.Name,
                    PromotionType = product.CurrentPromotion == null ? -1 : (int)product.CurrentPromotion.Type,
                });
            return productDTOList;
        }
    }
}