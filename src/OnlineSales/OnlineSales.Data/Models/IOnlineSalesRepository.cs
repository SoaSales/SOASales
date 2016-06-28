using System.Collections.Generic;
using System.Linq;

namespace OnlineSales.Data.Models
{
    public interface IOnlineSalesRepository
    {
        IQueryable<product> SearchProduct(List<string> searchParameters);
        IQueryable<product> SearchTopProducts(List<string> searchParameters, int numberOfProducts);
        product GetProduct(int productId);

        List<product> insert(List<product> products);
    }
}
