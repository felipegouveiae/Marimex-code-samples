namespace Samples.Solid.SRP;

public interface IOrder


{
    public int ProductId { get; set; }
    public uint Quantity { get; set; }
    public int ClientId { get; set; }

    public DateTime CreatedAt { get; set; }
}