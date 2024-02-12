public class Item
{
    public string SKU { get; }
    public string Name { get; }

    public Item(string sku, string name)
    {
        SKU = sku;
        Name = name;
    }
}
