using System;
using System.Collections.Generic;

namespace OnlineSales.Data.Models
{
    public partial class suppliersserviceoperation
    {
        public int ServiceOperationsId { get; set; }
        public int SupplierId { get; set; }
        public string Operation { get; set; }
        public string URL { get; set; }
        public string HTTAction { get; set; }
    }
}
