using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopOnContainers.Core.Models.PageCategory
{
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int? ParentID { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}