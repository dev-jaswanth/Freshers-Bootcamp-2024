public class StandardPricing : IPricingStrategy
{
    private readonly int _unitPrice;

    public StandardPricing(int unitPrice)
    {
        _unitPrice = unitPrice;
    }

    public int CalculatePrice(int quantity)
    {
        return _unitPrice * quantity;
    }
}
