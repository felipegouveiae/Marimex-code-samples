namespace Samples.Solid.SRP;

public class PlacedOrderDetails : IPlaceOrderResult
{
    public PlacedOrderDetails(Order order)
    {
        Order = order;
    }

    public Order Order { get; private set; }
}