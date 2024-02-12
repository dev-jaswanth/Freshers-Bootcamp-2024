using Xunit;
using System.Collections.Generic;

public class CheckoutTests
{
    private PricingStrategy SetupPricingRules()
    {
        var pricingRules = new PricingStrategy();
        // Now including the unit price as the third parameter for SpecialOfferPricing
        pricingRules.AddPricingStrategy("A", new SpecialOfferPricing(3, 130, 50)); // 3 for 130, with a unit price of 50
        pricingRules.AddPricingStrategy("B", new SpecialOfferPricing(2, 45, 30)); // 2 for 45, with a unit price of 30
        pricingRules.AddPricingStrategy("C", new StandardPricing(20)); // Standard pricing for C
        pricingRules.AddPricingStrategy("D", new StandardPricing(15)); // Standard pricing for D
        return pricingRules;
    }


    [Fact]
    public void EmptyCart_TotalShouldBeZero()
    {
        var checkout = new Checkout(SetupPricingRules());
        Assert.Equal(0, checkout.Total());
    }

    [Theory]
    [InlineData("C", 20)]
    [InlineData("D", 15)]
    public void SingleItemNoOffer_ShouldReturnStandardPrice(string sku, int expectedTotal)
    {
        var checkout = new Checkout(SetupPricingRules());
        checkout.Scan(sku);
        Assert.Equal(expectedTotal, checkout.Total());
    }

    [Theory]
    [InlineData("C", 2, 40)]
    [InlineData("D", 2, 30)]
    public void MultipleItemsNoOffer_ShouldReturnSummedPrice(string sku, int quantity, int expectedTotal)
    {
        var checkout = new Checkout(SetupPricingRules());
        for (int i = 0; i < quantity; i++)
        {
            checkout.Scan(sku);
        }
        Assert.Equal(expectedTotal, checkout.Total());
    }

    [Theory]
    [InlineData("A", 1, 50)]
    [InlineData("A", 2, 100)]
    [InlineData("B", 1, 30)]
    public void SingleItemWithOfferNotTriggered_ShouldReturnStandardPrice(string sku, int quantity, int expectedTotal)
    {
        var checkout = new Checkout(SetupPricingRules());
        for (int i = 0; i < quantity; i++)
        {
            checkout.Scan(sku);
        }
        Assert.Equal(expectedTotal, checkout.Total());
    }

    [Theory]
    [InlineData("A", 3, 130)]
    [InlineData("B", 2, 45)]
    public void OfferTriggeredExactly_ShouldApplyOfferPrice(string sku, int quantity, int expectedTotal)
    {
        var checkout = new Checkout(SetupPricingRules());
        for (int i = 0; i < quantity; i++)
        {
            checkout.Scan(sku);
        }
        Assert.Equal(expectedTotal, checkout.Total());
    }

    [Theory]
    [InlineData("A", 6, 260)]
    [InlineData("B", 4, 90)]
    public void OfferTriggeredMultipleTimes_ShouldApplyOfferPriceCorrectly(string sku, int quantity, int expectedTotal)
    {
        var checkout = new Checkout(SetupPricingRules());
        for (int i = 0; i < quantity; i++)
        {
            checkout.Scan(sku);
        }
        Assert.Equal(expectedTotal, checkout.Total());
    }

    [Fact]
    public void MixedItemsNoOffer_ShouldReturnSummedTotal()
    {
        var checkout = new Checkout(SetupPricingRules());
        checkout.Scan("A");
        checkout.Scan("B");
        checkout.Scan("C");
        checkout.Scan("D");
        Assert.Equal(115, checkout.Total()); // 50 + 30 + 20 + 15
    }

    [Fact]
    public void MixedItemsWithOffers_ShouldApplyOffersAndReturnTotal()
    {
        var checkout = new Checkout(SetupPricingRules());
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A"); // 3 for 130
        checkout.Scan("B");
        checkout.Scan("B"); // 2 for 45
        checkout.Scan("C"); // 20
        checkout.Scan("D"); // 15
        Assert.Equal(210, checkout.Total());
    }

    [Theory]
    [InlineData("A", 4, 180)] // 3 for 130 + 1 for 50
    [InlineData("B", 3, 75)]  // 2 for 45 + 1 for 30
    public void MultipleItemsWithExcess_ShouldApplyOfferAndStandardPrice(string sku, int quantity, int expectedTotal)
    {
        var checkout = new Checkout(SetupPricingRules());
        for (int i = 0; i < quantity; i++)
        {
            checkout.Scan(sku);
        }
        Assert.Equal(expectedTotal, checkout.Total());
    }

    [Fact]
    public void UnknownItemScanned_ShouldIgnoreAndNotChangeTotal()
    {
        var checkout = new Checkout(SetupPricingRules());
        checkout.Scan("Z"); // Assuming 'Z' is not configured
        Assert.Equal(0, checkout.Total());
    }
}
