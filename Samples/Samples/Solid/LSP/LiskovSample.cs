using Samples.Solid.OCP.Implementations;

namespace Samples.Solid.LSP;

public class LiskovSample
{
    private readonly List<AbstractBankCheckingAccount> _accounts = new();

    public double ConsolidateBalance()
    {
        var checkingAccount = new AbstractBankCheckingAccount();
        var savingsAccount = new AbstractBankSavingsAccount();
        var investingAccount = new AbstractBankInvestingAccount();
        var mortgageAccount= new MortgageAccount();

        _accounts.Add(checkingAccount);
        _accounts.Add(savingsAccount);
        _accounts.Add(investingAccount);
        _accounts.Add(mortgageAccount);

        return _accounts.Sum(x => x.Balance);
    }
}