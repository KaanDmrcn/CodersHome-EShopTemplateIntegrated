using eShopOnContainers.Core.Models.PageCategory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace eShopOnContainers.Core.Services.PageCategory
{
    public class CategoryMockService : ICategoryService
    {
        private ObservableCollection<Category> mocks = new ObservableCollection<Category>{

                new Category() { Name = "Kupa", Id = 1 },
                new Category() { Name = "Rozet", Id = 2 },
                new Category() { Name = "Defter", Id = 3 }
        };
        public async Task<ObservableCollection<Category>> GetCategoriesAsync()
        {
            await Task.Delay(10);
            return mocks;
        }
    }
}
