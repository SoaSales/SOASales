using System;
using System.Collections.Generic;

namespace OnlineSales.Data.Models
{
    public partial class supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
