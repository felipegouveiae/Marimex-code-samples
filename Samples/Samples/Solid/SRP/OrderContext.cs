namespace Samples.Solid.SRP;

public class OrderContext
{
    public IList<Product> Products { get; set; } = new List<Product>();
    public IList<Order> Orders { get; set; } = new List<Order>();

    public async Task SaveChanvesAsync()
    {
    }
}