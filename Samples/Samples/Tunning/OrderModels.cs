using System.Collections.ObjectModel;

namespace Samples.Tunning;

public class Order
{
    public int OrderId { get; set; }
    public int CreatedAt { get; set; }
    public int ClientId { get; set; }

    public Collection<Item> Items { get; set; } = new();
    // .... 
}

public class Item
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    // ,,, 
}


























