using System;
using System.Collections.Generic;

namespace OnlineSales.Data.Models
{
    public partial class product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public string OtherInfo { get; set; }
        public string MadeIn { get; set; }
        public string Seller { get; set; }
        public Nullable<int> ISBN { get; set; }
        public bool OutOfProduction { get; set; }
        public string Tags { get; set; }
        public string StorageLocation { get; set; }
    }
}
