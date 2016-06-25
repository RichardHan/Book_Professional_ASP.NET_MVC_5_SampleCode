using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsControllerSample.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int UnitsInStock { get; set; }
    }
}