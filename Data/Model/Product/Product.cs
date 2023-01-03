public class Product
{
    public long EAN { get; set; }
    public decimal Price { get; set; }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        return obj is Product product &&
               EAN == product.EAN;
    }
}
