using System.Collections.Generic;

namespace CheckoutSystem
{
    public class Checkout
    {
        private readonly Dictionary<string, int> prices = new Dictionary<string, int>
        {
            {"A", 50},
            {"B", 30},
            {"C", 20},
            {"D", 15}
        };
        private readonly Dictionary<string, (int quantity, int price)> offers = new Dictionary<string, (int, int)>
        {
            {"A", (3, 130)},
            {"B", (2, 45)}
        };
        private readonly Dictionary<string, int> cart = new Dictionary<string, int>();

        public void Scan(string item)
        {
            if (cart.ContainsKey(item))
                cart[item]++;
            else
                cart[item] = 1;
        }

        public int Total()
        {
            int total = 0;
            foreach (var item in cart)
            {
                if (offers.ContainsKey(item.Key) && item.Value >= offers[item.Key].quantity)
                {
                    var offer = offers[item.Key];
                    int offerBatches = item.Value / offer.quantity;
                    int remainder = item.Value % offer.quantity;
                    total += offerBatches * offer.price + remainder * prices[item.Key];
                }
                else
                {
                    total += item.Value * prices[item.Key];
                }
            }
            return total;
        }
    }
}
