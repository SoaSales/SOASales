using log4net;
using System;
using System.Collections.Generic;
using System.Reflection;
using OnlineSales.Data.Models;


namespace OnlineSales.RestServices.Services
{
    public class FindProductsService
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static product GetProducts(int productId)
        {
            logger.Info(string.Format("Obtaining product details, product Id = {0}", productId));

            product product = null;
            try
            {
                if (productId >= 0)
                {
                    IOnlineSalesRepository repository = new OnlineSalesRepository(new OnlineSalesContext());
                    product = repository.GetProduct(productId);
                }
            }
            catch (Exception exc)
            {
                logger.Error("Error obtaining product details.", exc);
            }

            return product;
        }

        public static List<product> SearchProducts(List<string> searchParameters)
        {
            logger.Info("searching products");

            List<product> producstList = new List<product>();
            try
            {
                if (searchParameters != null)
                {
                    IOnlineSalesRepository repository = new OnlineSalesRepository(new OnlineSalesContext());

                    producstList.AddRange(repository.SearchProduct(searchParameters));
                }
            }
            catch (Exception exc)
            {
                logger.Error("Error searching products.", exc);
            }

            return producstList;
        }

        public static List<product> LimitedSearch(List<string> searchParameters, int numberOfProducts)
        {
            logger.Info("searching limted products.");

            List<product> producstList = new List<product>();
            try
            {
                if (searchParameters != null)
                {
                    IOnlineSalesRepository repository = new OnlineSalesRepository(new OnlineSalesContext());

                    producstList.AddRange(repository.SearchTopProducts(searchParameters, numberOfProducts));
                }
            }
            catch (Exception exc)
            {
                logger.Error("Error searching limted products.", exc);
            }

            return producstList;
        }
    }
}