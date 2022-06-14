using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TableAttribute = SQLite.TableAttribute;

namespace eShopOnContainers.Core.Models
{
    [Table("CartItem")]
    public class CartItem
    {
        [PrimaryKey, AutoIncrement]
        public int CartItemID { get; set; }
        public int ProductID { get; set; }

        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public double Price { get; set; }
    }
}
