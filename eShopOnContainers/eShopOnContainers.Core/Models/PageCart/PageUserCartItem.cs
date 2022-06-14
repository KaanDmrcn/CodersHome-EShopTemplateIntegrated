using System;
using System.Collections.Generic;
using System.Text;

namespace eShopOnContainers.Core.Models.PageCart
{
    class PageUserCartItem
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }


        public double Price { get; set; }
        public double Cost { get; set; }
    }
}
