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
                //new Product { Id= 101, Name = "Softy Wellsoft Tv Battaniye 120x170 Cm Çikolata", Cost = 149.99, ImageURL = "https://cdn-eh.akinon.net/products/2021/10/05/189290/a3dbd199-bf0d-4f02-9921-d552b60eca6c_size768x575_cropCenter.jpg", Color = "Çikolata", rating = 0.0, CategoryID = 104 },
                //new Product { Id= 102, Name = "Liberty Bloom Pamuklu Çift Kişilik Nevresim Seti 200x220 Cm Tarçın", Cost = 499.99, ImageURL = "https://cdn-eh.akinon.net/products/2022/02/25/205114/462482ba-4a25-4fa4-9937-7bb5fa5efce5_size768x575_cropCenter.jpg", Color = "Pembe", rating = 0.0, CategoryID = 105},
                //new Product { Id= 103, Name = "Silikonlu Yastık 50X70 Cm Ekru", Cost = 99.99, ImageURL = "https://cdn-eh.akinon.net/products/2019/02/12/48498/3c437f1f-03d6-46f0-bec6-481e9d41c202_size768x575_cropCenter.jpg", Color = "Beyaz", rating = 0.0, CategoryID = 106 },
                //new Product { Id= 104, Name = "Siesta Mikrofiber Çift Kişilik Yorgan 195x215 Cm Beyaz", Cost = 499.99, ImageURL = "https://cdn-eh.akinon.net/products/2020/05/07/64997/b7f1464b-c40b-4ac0-8eb7-3d7842f0ae81_size768x575_cropCenter.jpg", Color = "Beyaz", rating = 0.0, CategoryID = 107 },

                //new Product { Id= 105, Name = "Icy Alüminyum Döküm Tencere Seti 7 Parça Siyah", Cost = 2449.99, ImageURL = "https://cdn-eh.akinon.net/products/2022/01/14/206695/4480a9c1-6fab-449b-923d-eb397607dfe7_size768x575_cropCenter.jpg", Color = "Siyah", rating = 0.0, CategoryID = 108 },
                //new Product { Id= 106, Name = "Cassidy Cam Kavanoz 1100 Ml Şeffaf", Cost = 109.99, ImageURL = "https://cdn-eh.akinon.net/products/2021/12/24/197796/ec1814ce-fae1-4850-83ae-025f0b505fd3_size768x575_cropCenter.jpg", Color = "Kahverengi", rating = 0.0, CategoryID = 109 },
                //new Product { Id= 107, Name = "Pamira Porselen 6 Kişilik Kahve Fincan Takımı 80 Ml Mavi", Cost = 249.99, ImageURL = "https://cdn-eh.akinon.net/products/2022/02/09/196669/bb0d9486-8962-4b22-82a0-73481aec8033_size768x575_cropCenter.jpg", Color = "Mavi", rating = 0.0, CategoryID = 110 },
                //new Product { Id= 108, Name = "Galia Butterfly Bone Porselen 12 Parça Yemek Takımı 25 - 20 - 15 Cm Pembe", Cost = 1199.99, ImageURL = "https://cdn-eh.akinon.net/products/2021/11/29/195330/a7459148-84bc-499d-8320-a24ccc7da6c3_size768x575_cropCenter.jpg", Color = "Beyaz-Altın", rating = 0.0, CategoryID = 111 },

                //new Product { Id= 109, Name = "Quadro Pamuklu 4'lü Set Havlu Seti 30x40 Cm Beyaz - Bordo", Cost = 119.99, ImageURL = "https://cdn-eh.akinon.net/products/2022/03/10/204593/4e3902ba-7b1b-46fb-ad47-b8fa438c09a3_size768x575_cropCenter.jpg", Color = "Beyaz", rating = 0.0, CategoryID = 112 },
                //new Product { Id=110, Name = "Casa Cam Banyo Sıvı Sabunluk 8x14 Cm Gold", Cost = 29.99, ImageURL = "https://cdn-eh.akinon.net/products/2020/09/17/167357/c43642db-f0fa-405a-88e1-e43181c97838_size768x575_cropCenter.jpg", Color = "Beyaz", rating = 0.0, CategoryID = 113 },
                //new Product { Id=111, Name = "Plain Pamuklu Bornoz L-xl Kiremit", Cost = 349.99, ImageURL = "https://cdn-eh.akinon.net/products/2022/04/19/210709/06c27a52-ab7c-4073-81ee-493f4acb79e8_size768x575_cropCenter.jpg", Color = "Kiremit", rating = 0.0, CategoryID = 114 },
                //new Product { Id=112, Name = "Evelyn 3'lü Banyo Seti Bej", Cost = 299.99, ImageURL = "https://cdn-eh.akinon.net/products/2022/04/19/206923/8f568c3c-3064-4430-9ed8-ccdfd1d10567_size768x575_cropCenter.jpg", Color = "Bej", rating = 0.0, CategoryID = 115 },

                //new Product { Id=113, Name = "Vera Şönil Halı Gri", Cost = 999.99, ImageURL = "https://cdn-eh.akinon.net/products/2021/06/22/180419/759d29d4-55cd-45cb-a235-3a63f2dc3482_size768x575_cropCenter.jpg", Color = "Gri", rating = 0.0, CategoryID = 116 },
                //new Product { Id=114, Name = "Fluffy Peluş Kırlent Kılıfı 45x45 cm Mürdüm", Cost = 119.99, ImageURL = "https://cdn-eh.akinon.net/products/2021/11/29/192494/2bb51d63-c5cd-449e-83e7-7f4fee5ca2f2_size768x575_cropCenter.jpg", Color = "Mürdüm", rating = 0.0, CategoryID = 117},
                //new Product { Id=115, Name = "Mace Polyester Masa Örtüsü 150x200 Cm Antrasit", Cost = 149.99, ImageURL = "https://cdn-eh.akinon.net/products/2021/11/22/200593/d5f45304-77be-4e51-8133-26639b95c3d6_size768x575_cropCenter.jpg", Color = "Mavi", rating = 0.0, CategoryID = 118},
                //new Product { Id=116, Name = "Marcel Sehpa 30x30x30 Cm Krem", Cost = 249.99, ImageURL = "https://cdn-eh.akinon.net/products/2021/04/20/177084/ba615c13-ba1c-429a-a8e8-f01cbd393f97_size768x575_cropCenter.jpg", Color = "Krem", rating = 0.0, CategoryID = 119 }
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
