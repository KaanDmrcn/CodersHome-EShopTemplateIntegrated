using eShopOnContainers.Core.Models.Product;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopOnContainers.Core.Services.Products
{
    public class ProductMockService : IProductsService
    {
        private ObservableCollection<Product> MockProducts = new ObservableCollection<Product>
        {
            new Product() { Id = 1, Name = "WordPres Temalı Yazılımcı Kupası", Cost = 42.95, ImageURL = "https://i0.wp.com/www.codershome.net/wp-content/uploads/2022/03/wordpress1-min.jpg?fit=1600%2C1200;ssl=1", CategoryName = "Kupa", CategoryID = 1 },
            new Product() { Id = 2, Name = "Lua Temalı Yazılımcı Kupası", Cost = 42.95, ImageURL = "https://i0.wp.com/www.codershome.net/wp-content/uploads/2022/03/lua-1-min.jpg?fit=1600%2C1200;ssl=1", CategoryName = "Kupa", CategoryID = 1 },
            new Product() { Id = 3, Name = "Pardus Temalı Yazılımcı Kupası", Cost = 42.95, ImageURL = "https://i0.wp.com/www.codershome.net/wp-content/uploads/2022/03/pardus-1-min.jpg?fit=1600%2C1200;ssl=1", CategoryName = "Kupa", CategoryID = 1 },
            new Product() { Id = 4, Name = "Flutter Temalı Yazılımcı İğneli Rozet", Cost = 7.50, ImageURL = "https://i0.wp.com/www.codershome.net/wp-content/uploads/2021/09/IMG_4120-min-scaled.jpg?fit=2560%2C2560;ssl=1", CategoryName = "Rozet", CategoryID = 2 },
            new Product() { Id = 5, Name = "Don't Disturb Karton Kapaklı Yazılımcı Siyah Defter", Cost = 54.95, ImageURL = "https://i0.wp.com/www.codershome.net/wp-content/uploads/2021/09/dont-disturb-min.jpg?fit=1200%2C1200;ssl=1", CategoryName = "Defter", CategoryID = 3 },
            new Product() { Id = 6, Name = "Anti Coding Coding Club Yazılımcı Siyah Defter", Cost = 54.95, ImageURL = "https://i0.wp.com/www.codershome.net/wp-content/uploads/2021/09/anti-coding-min.jpg?fit=1200%2C1200;ssl=1", CategoryName = "Defter", CategoryID = 3 }
        };
        public async Task<ObservableCollection<Product>> GetProductsAsync(int categoryID, string query)
        {
            await Task.Delay(10);
            return MockProducts;

        }

        public async Task<Product> GetProductWithIDAsync(int ID)
        {
            await Task.Delay(10);
            return MockProducts.First(x => x.Id == ID);
        }
    }
}
