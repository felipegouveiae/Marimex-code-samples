namespace Samples.Solid.OCP;

public class BankAccount
{
    private List<Transaction> _transactions = new();

    public double Balance { get; set; } = 0;

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
        => Balance = _transactions.Sum(x => x.Amount);
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