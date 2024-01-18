namespace Samples.Solid.OCP.Violations;

public enum AccountTypes
{
    Checking,
    Saving,
    Investing,
}

public class BankAccount
{
    private List<Transaction> _transactions = new();

    public double Balance { get; set; } = 0;
    public AccountTypes AccountType { get; set; } = AccountTypes.Checking;
    public decimal InterestRate { get; set; }
    public decimal InvestingInterestRate { get; set; }

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

    private void UpdateBalance()
    {
        if (AccountType == AccountTypes.Checking)
        {
            Balance = _transactions.Sum(x => x.Amount);
        }
        else if (AccountType == AccountTypes.Saving)
        {
            Balance = 0;

            foreach (var transaction in _transactions)
            {
                Balance += transaction.Amount;
                Balance += CalculateInterest(transaction.Amount, transaction.CreatedAt, InterestRate);
            }
        }
        else if (AccountType == AccountTypes.Investing)
        {
            Balance = 0;

            foreach (var transaction in _transactions)
            {
                Balance += transaction.Amount;
                Balance += CalculateInterest(transaction.Amount, transaction.CreatedAt, InvestingInterestRate);
            }
        }
    }

    private double CalculateInterest(double transactionAmount, DateTime transactionCreatedAt, decimal interestRate)
        => 0;
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