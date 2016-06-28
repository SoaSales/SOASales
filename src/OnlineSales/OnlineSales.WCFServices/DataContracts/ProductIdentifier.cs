using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace OnlineSales.WCFServices.DataContracts
{
    [DataContract]
    public class ProductIdentifierDataContract
    {
        [DataMember]
        public long ProductId { get; set; }
        [DataMember]
        public int VendorId { get; set; }

    }
}