using eShopOnContainers.Core.Models.PageCategory;
using eShopOnContainers.Core.Services.PageCategory;
using eShopOnContainers.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eShopOnContainers.Core.ViewModels
{
    public class CategoriesViewModel:ViewModelBase
    {
        private ObservableCollection<Category> _categories = new ObservableCollection<Category>();
        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                RaisePropertyChanged(() => Categories);
            }
        }
        private ICategoryService _service;
        public CategoriesViewModel()
        {
            _service = DependencyService.Get<ICategoryService>();
        }


        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            Categories = await _service.GetCategoriesAsync();
        }

        public ICommand NavigateProductsCommand => new Command<Category>(async (item) =>
        {
            await NavigationService.NavigateToAsync("Products", new Dictionary<string, string> { { "CategoryID", item.Id.ToString() } });
        });

        public ICommand NavigateLogin => new Command<string>(async (string query) =>
        {
            await NavigationService.NavigateToAsync("Login");
        });

        public ICommand NavigateCart => new Command(async () =>
        {
            await NavigationService.NavigateToAsync("Cart");
        });
    }
}
