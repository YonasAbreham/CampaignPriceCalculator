public class Product
{
    public long EAN { get; set; }
    public decimal Price { get; set; }

    /* 
     Product p1= new Product(EAN=102030);
     Product p2= new Product(EAN=102030);

    p1.Equals(p2) => false
    p1.Equals(p2) => true (with this Equals method)

    products = [p1, p2];
    producsts.Distinct() [p1, p2]
    producsts.Distinct() [p1] (with this Equals method)

     * */
    public override bool Equals(object? obj)
    {
        return obj is Product product &&
               EAN == product.EAN;
    }
}
