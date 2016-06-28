using System.Collections.Generic;
using OnlineSales.Portal.ProductService;

namespace OnlineSales.Portal.Models
{
    public class ProductViewModel
    {

    }

    public class ProductSearchModel
    {
        public ProductSearchModel()
        {
            ProductsList = new List<ProductsDataContract>();
        }

        public List<ProductsDataContract> ProductsList { get; set; }
        public string SearchParameters { get; set; }
        public List<ProductIdentifierDataContract> CompareProducts { get; set; }
    }

    public class ProductDetailsModel
    {
        public ProductsDataContract Product { get; set; }
    }

    public class ProductCompareModel
    {
        public ProductCompareModel()
        {
            ProductsList = new List<ProductsDataContract>();
        }

        public List<ProductsDataContract> ProductsList { get; set; }
    }

    public class RecentlyViewedModel
    {
        public RecentlyViewedModel()
        {
            ProductsList = new List<ProductsDataContract>();            
        }
        public List<ProductsDataContract> ProductsList { get; set; }
    }
}