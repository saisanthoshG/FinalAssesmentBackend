using System;
using System.Collections.Generic;

namespace FINALP.Products
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public DateTime? ProductManufacturingDate { get; set; }
        public DateTime? ProductExpiryDate { get; set; }
    }
}
