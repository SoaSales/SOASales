using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSales.Data.Models
{
    public class OnlineSalesRepository : IOnlineSalesRepository
    {
        private OnlineSalesContext _ctx;

        public OnlineSalesRepository(OnlineSalesContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<product> SearchProduct(List<string> searchParameters)
        {
            IQueryable<product> productsList = null;

            foreach (string parameter in searchParameters)
            {
                if (productsList == null)
                {
                    productsList = _ctx.products.Where(x => x.Name.Contains(parameter) || x.Description.Contains(parameter)
                    || x.OtherInfo.Contains(parameter) || x.Category.Contains(parameter));
                }
                else
                {
                    productsList.Concat(_ctx.products.Where(x => x.Name.Contains(parameter) || x.Description.Contains(parameter)
                        || x.OtherInfo.Contains(parameter) || x.Category.Contains(parameter)));
                }
            }

            return productsList;
        }

        public product GetProduct(int productId)
        {
            return _ctx.products.Find(productId);
        }


        public IQueryable<product> SearchTopProducts(List<string> searchParameters, int numberOfProducts)
        {
            IQueryable<product> productsList = null;

            foreach (string parameter in searchParameters)
            {
                if (productsList == null)
                {
                    productsList = (from prod in _ctx.products
                                where prod.Name.Contains(parameter) || prod.Description.Contains(parameter)
                                    select prod).Take(numberOfProducts);                    
                }
                else
                {
                    productsList.Concat(from prod in _ctx.products
                                        where prod.Name.Contains(parameter) || prod.Description.Contains(parameter)
                                        select prod).Take(numberOfProducts);
                }
                if (productsList.Count() >= numberOfProducts)
                {
                    break;
                }
            }           

            return productsList;
        }

        public List<product> insert(List<product> products)
        {
            List<product> productsList = products.GroupBy(x => x.Name).Select(p => p.First()).ToList();
            _ctx.products.AddRange(productsList);
            _ctx.SaveChanges();

            return productsList;
        }
    }
}
