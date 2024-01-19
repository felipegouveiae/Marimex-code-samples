using System.Transactions;

namespace Samples.Solid.SRP.Implementation;

public class OrderService
{
    public async Task<IPlaceOrderResult> PlaceOrderAsync(IOrderRequest orderRequest)
    {
        ArgumentNullException.ThrowIfNull(orderRequest);
        OrderRequestValidator.Validate(orderRequest);

        var product = await _productRepository.SingleAsync(orderRequest.ProductId);

        _stockChecker
            .ForProduct(product)
            .UnitsRequired(orderRequest.Quantity)
            .Check();

        using var scope = new TransactionScope();
        
        await _stockUpdateService
            .ForProduct(product)
            .WithdrawAsync(orderRequest.Quantity);

        var order = new Order(orderRequest, product);

        await _orderRepository.AddAsync(order);

        scope.Complete();
        
        return new PlacedOrderDetails(order);
    }

    #region ...
    
    private readonly IProductRepository _productRepository;
    private readonly IStockChecker _stockChecker;
    private readonly IStockUpdateService _stockUpdateService;
    private readonly IOrderRepository _orderRepository;

    public OrderService(
        IProductRepository productRepository,
        IStockChecker stockChecker,
        IStockUpdateService stockUpdateService,
        IOrderRepository orderRepository)
    {
        _productRepository = productRepository;
        _stockChecker = stockChecker;
        _stockUpdateService = stockUpdateService;
        _orderRepository = orderRepository;
    }

    #endregion
    
}

public interface IOrderRepository
{
    Task AddAsync(Order order);
}

public interface IStockUpdateService
{
    Task WithdrawAsync(uint units);
    IStockUpdateService ForProduct(Product product);
}

public class OrderRequestValidator
{
    public static void Validate(IOrderRequest orderRequest)
    {
        throw new NotImplementedException();
    }
}

public interface IStockChecker
{
    IStockChecker ForProduct(Product product);
    IStockChecker UnitsRequired(uint units);
    void Check();
}

public interface IProductRepository
{
    Task<Product> SingleAsync(int productId);
}