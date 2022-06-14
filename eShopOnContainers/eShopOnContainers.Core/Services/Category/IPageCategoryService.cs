using eShopOnContainers.Core.Models.PageCategory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace eShopOnContainers.Core.Services.PageCategory
{
    interface IPageCategoryService
    {
        Task<ObservableCollection<Category>> GetCategoriesAsync();
    }
}
