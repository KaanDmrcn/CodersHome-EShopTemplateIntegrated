using eShopOnContainers.Core.Models;
using eShopOnContainers.Core.Models.Product;
using eShopOnContainers.Core.Services.FixUri;
using eShopOnContainers.Core.Services.RequestProvider;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace eShopOnContainers.Core.Services.Cart
{
    public class CartService:ICartService
    {
        private string CartKey = "Cart";
        public ObservableCollection<CartItem> GetCartItems()
        {
            //Telefondan çekme kodu
            var cartD = Preferences.Get(CartKey, "");
            if (cartD == "") return new ObservableCollection<CartItem>();
            //String olarak çekilen sepetlistesi json.DeserializeObject ile Class listesine dönüştürülür.
            return JsonConvert.DeserializeObject<ObservableCollection<CartItem>>(cartD);
        }
        public void SaveCarts(ObservableCollection<CartItem> carts)
        {
            // Telefona kaydeder
            Preferences.Set(CartKey, JsonConvert.SerializeObject(carts));
        }
        public void AddToCart(Product product)
        {
            // telefondan çekilir sepet lokalden
            var carts = GetCartItems();
            if (carts.Any(x => x.ProductID == product.Id)) return;
            int id = 0;
            // sepetteki  son ürünün idsinden 1 fazla olacak eklenen ürün
            if(carts.Any()) id = carts[carts.Count - 1].CartItemID + 1;
            // listeye eklenir
            carts.Add(new CartItem() { CartItemID = id, Price = product.Cost, ProductID = product.Id, ProductName = product.Name });
            // telefona kaydedilir bu
            SaveCarts(carts);
        }
        public void RemoveFromCart(int CartID)
        {
            
            var carts = GetCartItems();
            // idsi CARTID olan bulunur silinir
            carts.Remove(carts.First(x => x.CartItemID == CartID));
            // liste kaydedilir.
            SaveCarts(carts);
        }
        public void ClearAll()
        {
            // Boş liste kaydedersek sepet temizlenir.
            SaveCarts(new ObservableCollection<CartItem>());
        }
    }
}
