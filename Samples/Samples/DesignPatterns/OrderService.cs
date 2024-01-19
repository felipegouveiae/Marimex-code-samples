using System.Transactions;
using Samples.Solid.SRP;

namespace Samples.DesignPatterns;

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

        await SendEmailToClientAsync(orderRequest);
        await SendSMSToClientAsync(orderRequest);
        await SendPushNotificationToClientAsync(orderRequest);

        return new PlacedOrderDetails(order);
    }

    private async Task SendPushNotificationToClientAsync(IOrderRequest orderRequest)
    {
        throw new NotImplementedException();
    }

    private async Task SendSMSToClientAsync(IOrderRequest orderRequest)
    {
        throw new NotImplementedException();
    }

    private async Task SendEmailToClientAsync(IOrderRequest orderRequest)
    {
        throw new NotImplementedException();
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

public class OrderService2
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

        await _dispatcher.DispatchAsync(new OrderCreatedEvent(order));

        return new PlacedOrderDetails(order);
    }

    #region ...

    private readonly IProductRepository _productRepository;
    private readonly IStockChecker _stockChecker;
    private readonly IStockUpdateService _stockUpdateService;
    private readonly IOrderRepository _orderRepository;
    private readonly IMediatorDispatcher _dispatcher;

    public OrderService2(
        IProductRepository productRepository,
        IStockChecker stockChecker,
        IStockUpdateService stockUpdateService,
        IOrderRepository orderRepository,
        IMediatorDispatcher dispatcher)
    {
        _productRepository = productRepository;
        _stockChecker = stockChecker;
        _stockUpdateService = stockUpdateService;
        _orderRepository = orderRepository;
        _dispatcher = dispatcher;
    }

    #endregion
}

public class OrderCreatedEvent : IEvent
{
    public Order Order { get; private set; }

    public OrderCreatedEvent(Order order)
    {
        Order = order;
    }
}

public class OrderPlacedEmailEventHandler : IEventHandler<OrderCreatedEvent>
{
    public async Task HandleAsync(OrderCreatedEvent eventData)
    {
        var body = BuildBody(eventData);

        await SendAsync(body, eventData.Order);
    }

    private async Task SendAsync(object body, Order eventDataOrder)
        => throw new NotImplementedException();

    private object BuildBody(OrderCreatedEvent eventData) 
        => throw new NotImplementedException();
}

public class OrderPlacedSMSEventHandler : IEventHandler<OrderCreatedEvent>
{
    public async Task HandleAsync(OrderCreatedEvent eventData)
    {
        var body = SMSBody(eventData);

        await SendSmsAsync(body, eventData.Order);
    }

    private async Task SendSmsAsync(object body, Order eventDataOrder)
        => throw new NotImplementedException();

    private object SMSBody(OrderCreatedEvent eventData) 
        => throw new NotImplementedException();
}

public class OrderPlacedPushEventHandler : IEventHandler<OrderCreatedEvent>
{
    public async Task HandleAsync(OrderCreatedEvent eventData)
    {
        var body = BuildPushBody(eventData);

        await SendPushAsync(body, eventData.Order);
    }

    private async Task SendPushAsync(object body, Order eventDataOrder)
        => throw new NotImplementedException();

    private object BuildPushBody(OrderCreatedEvent eventData) 
        => throw new NotImplementedException();
}



internal interface IEmailProvider
{
}

public interface IEventHandler<T>
    where T : IEvent
{
    Task HandleAsync(T eventData);
}

public interface IMediatorDispatcher
{
    Task DispatchAsync(IEvent @event);

    void Bind<TEvent, TEventHandler>()
        where TEvent : IEvent
        where TEventHandler : IEventHandler<TEvent>;
}

public interface IEvent
{
    
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

public class ServiceProvider
{
    private readonly IMediatorDispatcher _dispatcher = new DummyMediatorDispatcher();

    public void Bind()
    {
        _dispatcher.Bind<OrderCreatedEvent, OrderPlacedEmailEventHandler>();
        _dispatcher.Bind<OrderCreatedEvent, OrderPlacedSMSEventHandler>();
        _dispatcher.Bind<OrderCreatedEvent, OrderPlacedPushEventHandler>();
    }
}

public class DummyMediatorDispatcher : IMediatorDispatcher
{
    public Task DispatchAsync(IEvent @event)
    {
        throw new NotImplementedException();
    }

    public void Bind<TEvent, TEventHandler>() where TEvent : IEvent where TEventHandler : IEventHandler<TEvent>
    {
        throw new NotImplementedException();
    }
}