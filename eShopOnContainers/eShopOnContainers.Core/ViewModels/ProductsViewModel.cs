﻿using eShopOnContainers.Core.Extensions;
using eShopOnContainers.Core.Models.Product;
using eShopOnContainers.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eShopOnContainers.Core.ViewModels
{
    public class ProductsViewModel: ViewModelBase
    {
        private ObservableCollection<Product> AllProducts = new ObservableCollection<Product>()
            {
            new Product() { Id=0, Name = "WordPres Temalı Yazılımcı Kupası", Cost = 42.95, ImageURL= "https://i0.wp.com/www.codershome.net/wp-content/uploads/2022/03/wordpress1-min.jpg?fit=1600%2C1200;ssl=1", CategoryName= "Kupa", CategoryID=1},
            new Product() { Id=1, Name = "Lua Temalı Yazılımcı Kupası", Cost = 42.95, ImageURL= "https://i0.wp.com/www.codershome.net/wp-content/uploads/2022/03/lua-1-min.jpg?fit=1600%2C1200;ssl=1", CategoryName= "Kupa",CategoryID=1},
            new Product() { Id=2, Name = "Pardus Temalı Yazılımcı Kupası", Cost = 42.95, ImageURL= "https://i0.wp.com/www.codershome.net/wp-content/uploads/2022/03/pardus-1-min.jpg?fit=1600%2C1200;ssl=1", CategoryName= "Kupa",CategoryID=1},
            new Product() { Id=3, Name = "Flutter Temalı Yazılımcı İğneli Rozet", Cost = 7.50, ImageURL= "https://i0.wp.com/www.codershome.net/wp-content/uploads/2021/09/IMG_4120-min-scaled.jpg?fit=2560%2C2560;ssl=1", CategoryName= "Rozet",CategoryID=2},
            new Product() { Id=4, Name = "Don't Disturb Karton Kapaklı Yazılımcı Siyah Defter", Cost = 54.95, ImageURL= "https://i0.wp.com/www.codershome.net/wp-content/uploads/2021/09/dont-disturb-min.jpg?fit=1200%2C1200;ssl=1", CategoryName= "Defter",CategoryID=3},
            new Product() { Id=5, Name = "Anti Coding Coding Club Yazılımcı Siyah Defter", Cost = 54.95, ImageURL= "https://i0.wp.com/www.codershome.net/wp-content/uploads/2021/09/anti-coding-min.jpg?fit=1200%2C1200;ssl=1", CategoryName= "Defter",CategoryID=3}
            };

        private IProductsService _productsService;
        public ProductsViewModel()
        {
            _productsService = DependencyService.Get<IProductsService>();

        }

        private ObservableCollection<Product> products = new ObservableCollection<Product>();

        public ObservableCollection<Product> Products
        {
            get => products;
            set
            {
                products = value;
                OnPropertyChanged();
            }
        }

        public override Task InitializeAsync(IDictionary<string, string> query)
        {
            if (query != null)
            {

                if (query.ContainsKey("CategoryID"))
                    CategoryID = query.GetValueAsInt("CategoryID").Value;

                if (query.ContainsKey("SearchQuery"))
                    SearchQuery = query["SearchQuery"];
            }
            Products = AllProducts;
            Filter();
            return base.InitializeAsync(query);
        }

        public ICommand NavigateLogin => new Command<string>(async (string query) =>
        {
            await NavigationService.NavigateToAsync("Login");
        });

        public ICommand NavigateCart => new Command(async () =>
        {
            await NavigationService.NavigateToAsync("Cart");
        });

        public ICommand Search => new Command<string>((string query) =>
        {

            SearchQuery = query;
            IsBusy = true;
            Filter();
            IsBusy = false;
        });

        public string SearchQuery { get; private set; } = "";
        public int CategoryID { get; private set; } = -1;

        void Filter()
        {
            Products = AllProducts.Where(x => (CategoryID < 0 || CategoryID == x.CategoryID) && x.Name.ToLower().Contains(SearchQuery.ToLower())).ToObservableCollection();
        }


        public ICommand NavigateProductDetail => new Command<Product>(async (item) =>
        {
            await NavigationService.NavigateToAsync("ProductDetail", new Dictionary<string, string> { { "Product", item.Id.ToString() } });
        });
    }
}
