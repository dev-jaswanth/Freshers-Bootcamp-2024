using System.Collections.Generic;

public class PricingStrategy

{
    private readonly Dictionary<string, IPricingStrategy> _pricingStrategies = new Dictionary<string, IPricingStrategy>();

    public void AddPricingStrategy(string sku, IPricingStrategy pricingStrategy)
    {
        _pricingStrategies[sku] = pricingStrategy;
    }

    public int GetPrice(string sku, int quantity)
    {
        if (_pricingStrategies.TryGetValue(sku, out var strategy))
        {
            return strategy.CalculatePrice(quantity);
        }
        return 0; // Consider whether to throw an exception for unknown items
    }
}
