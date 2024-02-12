using System.Collections.Generic;

public class Checkout
{
    private readonly PricingStrategy _pricingRules;
    private readonly Dictionary<string, int> _items = new Dictionary<string, int>();

    // Update constructor parameter to expect PricingRules instead of IPricingStrategy
    public Checkout(PricingStrategy pricingRules)
    {
        _pricingRules = pricingRules;
    }

    public void Scan(string sku)
    {
        if (_items.ContainsKey(sku))
        {
            _items[sku]++;
        }
        else
        {
            _items[sku] = 1;
        }
    }

    public int Total()
    {
        int total = 0;
        foreach (var item in _items)
        {
            total += _pricingRules.GetPrice(item.Key, item.Value);
        }
        return total;
    }
}
