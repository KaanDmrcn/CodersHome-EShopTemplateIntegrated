using eShopOnContainers.Core.Models;
using eShopOnContainers.Core.Models.Product;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace eShopOnContainers.Core.Services.Cart
{
    public class CartMockService : ICartService
    {

        ObservableCollection<CartItem> cartItems = new ObservableCollection<CartItem>() {
            new CartItem()
            {
                CartItemID = 0, Price = 250, ProductID = 100, ProductName = "Yastık", ProductImage = "https://cdn-eh.akinon.net/products/2021/10/05/189290/a3dbd199-bf0d-4f02-9921-d552b60eca6c_size768x575_cropCenter.jpg",
            },
            new CartItem()
            {
                CartItemID = 1, Price = 350, ProductID = 101, ProductName = "Kırlent", ProductImage = "https://cdn-eh.akinon.net/products/2021/10/05/189290/a3dbd199-bf0d-4f02-9921-d552b60eca6c_size768x575_cropCenter.jpg",
            }
        };


        public void AddToCart(Product product)
        {
            cartItems.Add(new CartItem() { CartItemID = cartItems[cartItems.Count - 1].CartItemID + 1, Price = product.Cost, ProductImage = product.ImageURL, ProductName = product.Name });
        }

        public void ClearAll()
        {
            cartItems.Clear();
        }

        public ObservableCollection<CartItem> GetCarts()
        {
            return cartItems;
        }

        public void PostCarts(ObservableCollection<CartItem> carts)
        {
            foreach(CartItem cart in carts)
            {
                cartItems.Add(cart);
            }
            
        }

        public void RemoveFromCart(int CartID)
        {
            cartItems.Remove(cartItems.First(x => x.CartItemID == CartID));
        }
    }
}
