using Klir.TechChallenge.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api.Services
{
    public class ProductService
    {
        public IEnumerable<Product> GetAllAvailableProducts()
        {
            return Product.ProductList;
        }
    }
}
