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
            new CartItem() {CartItemID = 1, ProductID = 1, Price= 42.95, ProductName = "Android Studio Temalı Kupa"},
            new CartItem() {CartItemID = 1, ProductID = 1, Price= 42.95, ProductName = "Android Studio Temalı Kupa"}
        };


        public void AddToCart(Product product)
        {
            cartItems.Add(new CartItem() { CartItemID = cartItems[cartItems.Count - 1].CartItemID + 1, Price = product.Cost, ProductName = product.Name });
        }

        public void ClearAll()
        {
            cartItems.Clear();
        }

        public ObservableCollection<CartItem> GetCartItems()
        {
            return cartItems;
        }

        public void SaveCarts(ObservableCollection<CartItem> carts)
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
