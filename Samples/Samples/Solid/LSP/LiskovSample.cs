using Samples.Solid.OCP.Implementations;

namespace Samples.Solid.LSP;

public class LiskovSample
{
    private readonly List<BankCheckingAccount> _accounts = new();

    public double ConsolidateBalance()
    {
        var checkingAccount = new BankCheckingAccount();
        var savingsAccount = new BankSavingsAccount();
        var investingAccount = new BankInvestingAccount();
        var mortgageAccount= new MortgageAccount();

        _accounts.Add(checkingAccount);
        _accounts.Add(savingsAccount);
        _accounts.Add(investingAccount);
        _accounts.Add(mortgageAccount);

        return _accounts.Sum(x => x.Balance);
    }
}