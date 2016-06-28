using log4net;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Xml;
using OnlineSales.Portal.ProductService;

namespace OnlineSales.Portal.Utils
{
    public class XmlToProductConverter
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static List<ProductsDataContract> convertToProductList(WebResponse response)
        {
            List<ProductsDataContract> productList = new List<ProductsDataContract>();

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());

                string nodeName = "entities.product";
                XmlNodeList productNodes = xmlDoc.GetElementsByTagName(nodeName);

                foreach (XmlNode node in productNodes)
                {
                    ProductsDataContract product = new ProductsDataContract();

                    if (node.SelectSingleNode("ProductId") != null)
                    {
                        product.ProductId = Int64.Parse(node.SelectSingleNode("ProductId").InnerText);
                    }

                    if (node.SelectSingleNode("VendorId") != null)
                    {
                        product.VendorId = Int32.Parse(node.SelectSingleNode("VendorId").InnerText);
                    }

                    if (node.SelectSingleNode("VendorName") != null)
                    {
                        product.VendorName = node.SelectSingleNode("VendorName").InnerText;
                    }

                    if (node.SelectSingleNode("Name") != null)
                    {
                        product.Name = node.SelectSingleNode("Name").InnerText;
                    }

                    if (node.SelectSingleNode("Description") != null)
                    {
                        product.Description = node.SelectSingleNode("Description").InnerText;
                    }
                  
                    if (node.SelectSingleNode("Price") != null)
                    {
                        string price = node.SelectSingleNode("Price").InnerText;
                        if (!string.IsNullOrWhiteSpace(price))
                        {
                            product.Price = float.Parse(price, CultureInfo.InvariantCulture);
                        }
                    }

                    if (node.SelectSingleNode("Quantity") != null)
                    {
                        string quantity = node.SelectSingleNode("Quantity").InnerText;
                        if (!string.IsNullOrWhiteSpace(quantity))
                        {
                            product.Quantity = Int32.Parse(quantity);
                        }
                    }

                    if (node.SelectSingleNode("Category") != null)
                    {
                        product.Category = node.SelectSingleNode("Category").InnerText;
                    }

                    if (node.SelectSingleNode("Other_Info") != null)
                    {
                        product.Other_Info = node.SelectSingleNode("Other_Info").InnerText;
                    }

                    productList.Add(product);
                }
            }
            catch (Exception exc)
            {
                log.Error("Request Compare", exc);
            }

            return productList;
        }

        public static ProductsDataContract convertToProduct(WebResponse response)
        {
            ProductsDataContract product = new ProductsDataContract();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(response.GetResponseStream());

            string nodeName = "entities.product";
            XmlNode productNode = xmlDoc.GetElementsByTagName(nodeName)[0];

            if (productNode.SelectSingleNode("ProductId") != null)
            {
                product.ProductId = Int64.Parse(productNode.SelectSingleNode("ProductId").InnerText);
            }

            if (productNode.SelectSingleNode("VendorId") != null)
            {
                product.VendorId = Int32.Parse(productNode.SelectSingleNode("VendorId").InnerText);
            }

            if (productNode.SelectSingleNode("VendorName") != null)
            {
                product.VendorName = productNode.SelectSingleNode("VendorName").InnerText;
            }

            if (productNode.SelectSingleNode("Name") != null)
            {
                product.Name = productNode.SelectSingleNode("Name").InnerText;
            }

            if (productNode.SelectSingleNode("Description") != null)
            {
                product.Description = productNode.SelectSingleNode("Description").InnerText;
            }

            if (productNode.SelectSingleNode("Price") != null)
            {
                string price = productNode.SelectSingleNode("Price").InnerText;
                if (!string.IsNullOrWhiteSpace(price))
                {
                    product.Price = float.Parse(price, CultureInfo.InvariantCulture);
                }
            }

            if (productNode.SelectSingleNode("Quantity") != null)
            {
                string quantity = productNode.SelectSingleNode("Quantity").InnerText;
                if (!string.IsNullOrWhiteSpace(quantity))
                {
                    product.Quantity = Int32.Parse(quantity);
                }
            }

            if (productNode.SelectSingleNode("Category") != null)
            {
                product.Category = productNode.SelectSingleNode("Category").InnerText;
            }

            if (productNode.SelectSingleNode("Other__Info") != null)
            {
                product.Other_Info = productNode.SelectSingleNode("Other__Info").InnerText;
            }

            return product;
        }
    }
}