using log4net;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Web.Configuration;
using System.Web.Mvc;
using OnlineSales.Portal.Models;
using OnlineSales.Portal.ProductService;
using OnlineSales.Portal.Utils;

namespace OnlineSales.Portal.Controllers
{
    public class ProductController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static List<ProductIdentifierDataContract> compareProductsIdentifiers = new List<ProductIdentifierDataContract>();        
        private static string SearchParameters = string.Empty;         

        public ProductController()
        {           
        }

        // GET: Product/Details
        public ActionResult Details(long productId, int vendorId)
        {
            log.Info("Details request");
            var model = new ProductDetailsModel();

            try
            {
                var Url = WebConfigurationManager.AppSettings["MuleESBUrl"];
                var request = string.Format("{0}/api/ProductsService/Get?id={1}&vendor={2}", Url, productId, vendorId);
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(request);
                httpRequest.Method = "GET";

                WebResponse response = httpRequest.GetResponse();

                model.Product = XmlToProductConverter.convertToProduct(response);
            }
            catch (Exception exc)
            {
                log.Error("Details request", exc);
            }

            return View(model);
        }

        // GET: Product/Search
        public ActionResult SearchProduct(ProductSearchModel model)
        {
            log.Info("Request Search");

            if (model.SearchParameters != null)
            {
                try
                {
                    var Url = WebConfigurationManager.AppSettings["MuleESBUrl"];
                    var request = string.Format("{0}/api/ProductsService/Search?searchParameters={1}", Url, model.SearchParameters);
                    HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(request);                   
                    httpRequest.Method = "GET";

                    WebResponse response = httpRequest.GetResponse();

                    model.ProductsList = XmlToProductConverter.convertToProductList(response);
                }
                catch (Exception exc)
                {
                    log.Error("Search Request", exc);
                }
            }
            return View("Search", model);
        }

        public ActionResult Search()
        {
            ProductSearchModel model = new ProductSearchModel();

            return View(model);
        }

        // GET: Product/Compare
        public ActionResult Compare(ProductSearchModel model)
        {
            log.Info("Request Compare");

            ProductCompareModel compareModel = new ProductCompareModel();

            if (compareProductsIdentifiers.Count != 0)
            {
                CompareProductsService service = new CompareProductsService();

                try
                {
                    ProductIdentifierDataContract[] products = compareProductsIdentifiers.ToArray();

                    ProductsDataContract[] response = service.CompareProducts(products);

                    foreach (ProductsDataContract product in response)
                    {
                        compareModel.ProductsList.Add(new ProductsDataContract()
                        {
                            ProductId = product.ProductId,
                            VendorId = product.VendorId,
                            VendorName = product.VendorName,
                            Name = product.Name,
                            Description = product.Description,
                            Category = product.Category,
                            Other_Info = product.Other_Info,
                            Price = product.Price,
                            Quantity = product.Quantity
                        });
                    }
                }
                catch (Exception exc)
                {
                    log.Error("Request Compare", exc);
                }
                finally
                {
                    service.Dispose();
                }
            }

            compareProductsIdentifiers.Clear();
            return View("Compare", compareModel);
        }

        public void AddCompareItem(long productId, int vendorId)
        {
            if (compareProductsIdentifiers.Count < 5 && productId >= 0 && vendorId >= 0)
            {
                compareProductsIdentifiers.Add(new ProductIdentifierDataContract()
                {
                    ProductId = productId,
                    VendorId = vendorId,
                    ProductIdSpecified = true,
                    VendorIdSpecified = true
                });
            }
        }

        public void RemoveCompareItem(long productId, int vendorId)
        {
            if (productId >= 0 && vendorId >= 0)
            {
                ProductIdentifierDataContract product = compareProductsIdentifiers.Find(x => x.VendorId == vendorId && x.ProductId == productId);
                compareProductsIdentifiers.Remove(product);
            }
        }       
    }
}
