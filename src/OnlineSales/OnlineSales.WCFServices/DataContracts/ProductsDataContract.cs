using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace OnlineSales.WCFServices.DataContracts
{
    [DataContract]
    public class ProductsDataContract
    {
        [DataMember]
        public long ProductId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public float Price { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string Other_Info { get; set; }
        [DataMember]
        public int VendorId { get; set; }
         [DataMember]
        public string VendorName { get; set; }
    }
}