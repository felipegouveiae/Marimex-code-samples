namespace Samples.Solid.SRP;

public class Order : IOrder
{
    public Order(IOrderRequest orderRequest, Product product)
    {
        ProductId = product.ProductId;
        Quantity = orderRequest.Quantity;
        ClientId = orderRequest.ClientId;
    }

    public int ProductId { get; set; }
    public uint Quantity { get; set; }
    public int ClientId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}