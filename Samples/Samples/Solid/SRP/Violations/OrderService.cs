namespace Samples.Solid.SRP.Violations;

public class OrderService
{
    public async Task<IPlaceOrderResult> PlaceOrderAsync(IOrderRequest orderRequest)
    {
        ArgumentNullException.ThrowIfNull(orderRequest);

        var dataContext = new OrderContext();

        var product = dataContext.Products
            .SingleOrDefault(x => x.ProductId == orderRequest.ProductId && !x.Deleted);

        if (product is null)
            throw new ProductNotFoundException();

        if (product.UnitsInStock < orderRequest.Quantity)
            throw new ProductOutOfStockException(orderRequest.Quantity,
                product.UnitsInStock);

        if (orderRequest.Quantity <= 0)
            throw new InvalidQuantityException();

        var order = new Order(orderRequest, product);

        dataContext.Orders.Add(order);

        product.UnitsInStock -= orderRequest.Quantity;

        await dataContext.SaveChanvesAsync();

        return new PlacedOrderDetails(order);
    }
}

public interface IProductRepository
{
    Task<Product> SingleAsync(int productId);
}