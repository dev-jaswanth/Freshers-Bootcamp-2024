public class SpecialOfferPricing : IPricingStrategy
{
    private readonly int _bundleQuantity;
    private readonly int _bundlePrice;
    private readonly int _unitPrice;

    public SpecialOfferPricing(int bundleQuantity, int bundlePrice, int unitPrice)
    {
        _bundleQuantity = bundleQuantity;
        _bundlePrice = bundlePrice;
        _unitPrice = unitPrice;
    }

    public int CalculatePrice(int quantity)
    {
        int bundleCount = quantity / _bundleQuantity;
        int remainder = quantity % _bundleQuantity;
        return bundleCount * _bundlePrice + remainder * _unitPrice;
    }
}
