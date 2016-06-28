using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using OnlineSales.WCFServices.DataContracts;

namespace OnlineSales.WCFServices.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CompareProductsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CompareProductsService.svc or CompareProductsService.svc.cs at the Solution Explorer and start debugging.
    public class CompareProductsService : ICompareProductsService
    {
        public List<ProductsDataContract> CompareProducts(List<ProductIdentifierDataContract> products)
        {
            List<ProductsDataContract> productsList = new List<ProductsDataContract>();

            productsList.Add(new ProductsDataContract() { ProductId = 1, Category = "book", Name = "book xpto", Description = "description", Quantity = 10, VendorId = 1, VendorName = "Vendor" });

            return productsList;

        }
    }
}
