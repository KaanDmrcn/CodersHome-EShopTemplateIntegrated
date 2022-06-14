using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eShopOnContainers.Core.Models
{
    public class CartItem
    {
        public int CartItemID { get; set; }
        public int ProductID { get; set; }

        public string ProductName { get; set; }
        public double Price { get; set; }
    }
}
