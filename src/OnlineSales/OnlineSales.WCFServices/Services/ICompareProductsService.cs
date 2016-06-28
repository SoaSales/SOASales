using OnlineSales.WCFServices.DataContracts;
using System.Collections.Generic;
using System.ServiceModel;

namespace OnlineSales.WCFServices.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICompareProductsService" in both code and config file together.
    [ServiceContract]
    public interface ICompareProductsService
    {
        [OperationContract]
        List<ProductsDataContract> CompareProducts(List<ProductIdentifierDataContract> products);
    }
}
