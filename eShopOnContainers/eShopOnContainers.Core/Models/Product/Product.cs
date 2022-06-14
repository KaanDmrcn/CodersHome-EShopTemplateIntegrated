using eShopOnContainers.Core.Models.PageCategory;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopOnContainers.Core.Models.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string ImageURL { get; set; }
    }
}
