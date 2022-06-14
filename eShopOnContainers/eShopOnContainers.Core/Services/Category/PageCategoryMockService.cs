using eShopOnContainers.Core.Models.PageCategory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace eShopOnContainers.Core.Services.PageCategory
{
    public class PageCategoryMockService : IPageCategoryService
    {
        private ObservableCollection<Category> mocks = new ObservableCollection<Category>{

                new Category { Id = 100, Name = "Yatak Odası",  },
                new Category { Id = 101, Name = "Mutfak" },
                new Category { Id = 102, Name = "Banyo" },
                new Category { Id = 103, Name = "Salon" },

                new Category { Id = 104, ParentID = 100, Name = "Battaniye" },
                new Category { Id = 105, ParentID = 100, Name = "Nevresim Seti" },
                new Category { Id = 106, ParentID = 100, Name = "Yastık" },
                new Category { Id = 107, ParentID = 100, Name = "Yorgan" },

                new Category { Id = 108, ParentID = 101, Name = "Tencere" },
                new Category { Id = 109, ParentID = 101, Name = "Kavanoz" },
                new Category { Id = 110, ParentID = 101, Name = "Fincan Seti" },
                new Category { Id = 111, ParentID = 101, Name = "Yemek Takımı" },

                new Category { Id = 112, ParentID = 102, Name = "Havlu" },
                new Category { Id = 113, ParentID = 102, Name = "Sabunluk" },
                new Category { Id = 114, ParentID = 102, Name = "Bornoz" },
                new Category { Id = 115, ParentID = 102, Name = "Banyo Seti" },

                new Category { Id = 116, ParentID = 103, Name = "Halı" },
                new Category { Id = 117, ParentID = 103, Name = "Kırlent" },
                new Category { Id = 118, ParentID = 103, Name = "Masa Örtüsü" },
                new Category { Id = 119, ParentID = 103, Name = "Sehpa" }};
        public async Task<ObservableCollection<Category>> GetCategoriesAsync()
        {
            await Task.Delay(10);
            return mocks;
        }
    }
}
