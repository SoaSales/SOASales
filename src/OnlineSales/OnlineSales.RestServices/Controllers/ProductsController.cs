using System.Collections.Generic;
using System.Web.Http;
using OnlineSales.Data.Models;
using OnlineSales.RestServices.Services;

namespace OnlineSales.RestServices.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        /// <summary>
        /// Gets a product using the product's identifier
        /// </summary>
        /// <param name="id">The product unique identifier</param>
        /// <returns>A product</returns>
        [Route("{id:int}")]
        public product Get(int id)
        {
            return FindProductsService.GetProducts(id);
        }

        /// <summary>
        /// Gets a list of products that match the search criteria
        /// </summary>
        /// <param name="searchParameters">The search criteria</param>
        /// <returns>A list of products</returns>
        [Route("Search"),
        HttpGet]
        public List<product> SearchProduct(string searchParameters)
        {
            List<string> parameters = new List<string>();
            parameters.AddRange(searchParameters.Split(' '));

            return FindProductsService.SearchProducts(parameters);
        }

        /// <summary>
        /// Gets a list of products with a limited number of products that match the search criteria
        /// </summary>
        /// <param name="searchParameters">The search criteria</param>
        /// <param name="numberOfProducts">Max number of products to return</param>
        /// <returns>A list of products</returns>
        [Route("SimpleSearch"),
        HttpGet]
        public List<product> LimitedSearchProduct(string searchParameters, int numberOfProducts)
        {
            List<string> parameters = new List<string>();
            parameters.AddRange(searchParameters.Split(' '));

            return FindProductsService.LimitedSearch(parameters, numberOfProducts);
        } 
    }
}
