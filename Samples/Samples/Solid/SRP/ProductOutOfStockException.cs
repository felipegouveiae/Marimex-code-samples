namespace Samples.Solid.SRP;

public class ProductOutOfStockException : Exception
{
    public ProductOutOfStockException(uint requestedQuantity, uint availableQuantity)
        : base($"The requested quantity ({requestedQuantity} is not available. " +
               $"There are only {availableQuantity} in stock")
    {
    }
}