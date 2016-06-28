using System.Collections.Generic;
using System.ServiceModel;
using OnlineSales.WCFServices.DataContracts;

namespace OnlineSales.WCFServices.Services
{   
    [ServiceContract]
    public interface IProductsService
    {
        [OperationContract]
        List<ProductsDataContract> SearchProduct(List<string> searchParameters);

        [OperationContract]
         ProductsDataContract ViewProduct(int productId, int vendorId);

        [OperationContract]
        List<ProductsDataContract> CompareProducts(List<ProductIdentifierDataContract> products);
    }
}
