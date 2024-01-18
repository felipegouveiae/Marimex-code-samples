using Samples.Solid.OCP.Implementations;

namespace Samples.Solid.LSP;

public class MortgageAccount : AbstractBankCheckingAccount
{
    public new double Balance
    {
        get => throw new InvalidOperationException();
        set => throw new InvalidOperationException();
    }
}