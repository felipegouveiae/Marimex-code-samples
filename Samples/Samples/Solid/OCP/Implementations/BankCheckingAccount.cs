namespace Samples.Solid.OCP.Implementations;

public abstract class AbstractBankAccount
{
    public double Balance { get; set; } = 0;
}

public class BankCheckingAccount : AbstractBankAccount
{
    private List<Transaction> _transactions = new();

    public IReadOnlyList<Transaction> Transactions
    {
        get => _transactions;
        protected set => _transactions.AddRange(value);
    }

    public void Deposit(double amount, string description)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException();

        _transactions.Add(new Transaction(amount, description));

        UpdateBalance();
    }

    protected virtual void UpdateBalance()
        => Balance = _transactions.Sum(x => x.Amount);
}

public class BankSavingsAccount : BankCheckingAccount
{
    public decimal InterestRate { get; set; }

    protected override void UpdateBalance()
    {
        Balance = 0;

        foreach (var transaction in Transactions)
        {
            Balance += transaction.Amount;
            Balance += CalculateInterest(transaction.Amount, transaction.CreatedAt);
        }
    }

    private double CalculateInterest(double transactionAmount,
        DateTime transactionCreatedAt)
    {
        var subtotal = (DateTime.Now - transactionCreatedAt).Days
                       * ((1M + InterestRate) / 365M);

        return Convert.ToDouble(subtotal);
    }
}

public class BankInvestingAccount : BankSavingsAccount
{
    public decimal InvestingInterestRate { get; set; }

    protected override void UpdateBalance()
    {
        Balance = 0;

        foreach (var transaction in Transactions)
        {
            Balance += transaction.Amount;
            Balance += CalculateInterest(transaction.Amount, transaction.CreatedAt);
        }
    }

    private double CalculateInterest(double transactionAmount,
        DateTime transactionCreatedAt)
    {
        var subtotal = (DateTime.Now - transactionCreatedAt).Days
                       * ((1.15M + InvestingInterestRate) / 365M);

        return Convert.ToDouble(subtotal);
    }
}

public class Transaction
{
    public Transaction(double amount, string description)
    {
        Amount = amount;
        Description = description;
    }

    public DateTime CreatedAt { get; } = DateTime.Now;
    public double Amount { get; set; }
    public string Description { get; set; }
}

public enum AccountTypes
{
    Checking,
    Saving,
    Investing,
}