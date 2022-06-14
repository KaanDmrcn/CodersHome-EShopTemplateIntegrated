using eShopOnContainers.Core.Models.Product;
using eShopOnContainers.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopOnContainers.Core.ViewModels
{
    public class ProductDetailViewModel: ViewModelBase
    {

        private Product _product = new Product() { Id = 0, Name = "WordPres Temalı Yazılımcı Kupası", Cost = 42.95, ImageURL = "https://i0.wp.com/www.codershome.net/wp-content/uploads/2022/03/wordpress1-min.jpg?fit=1600%2C1200;ssl=1", CategoryName = "Kupa", CategoryID = 1 };
        public Product Product
        {
            get => _product;
            set
            {
                _product = value;
                RaisePropertyChanged(() => Product);
            }
        }
        public override Task InitializeAsync(IDictionary<string, string> query)
        {
            return base.InitializeAsync(query);
        }
    }
}
