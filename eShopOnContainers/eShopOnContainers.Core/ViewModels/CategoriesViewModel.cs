using eShopOnContainers.Core.Models.PageCategory;
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
        private ObservableCollection<Category> _categories = new ObservableCollection<Category>()
        {
            new Category(){ Name = "Kupa", Id = 1},
            new Category(){ Name = "Rozet", Id = 2},
            new Category(){ Name = "Defter", Id = 3}
        };
        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                RaisePropertyChanged(() => Categories);
            }
        }
        public override Task InitializeAsync(IDictionary<string, string> query)
        {
            return base.InitializeAsync(query);
        }

        public ICommand NavigateProductsCommand => new Command<Category>(async (item) =>
        {
            IsBusy = true;
            await NavigationService.NavigateToAsync("Products", new Dictionary<string, string> { { "CategoryID", item.Id.ToString() } });
            IsBusy = false;
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
