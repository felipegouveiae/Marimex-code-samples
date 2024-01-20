using Samples.Solid.OCP.Implementations;

namespace Samples.DesignPatterns;

public class BankAccountAbstractFactory
{
    public AbstractBankAccount CreateAccount(IClient client)
    {
        switch (client.ClientType)
        {
            case ClientTypes.Company:
                return new BankInvestingAccount();
            case ClientTypes.Person:
                return new BankCheckingAccount();
            default:
                throw new UnsupportedClientTypeException();
        }
    }
}

public class UnsupportedClientTypeException : Exception
{
}


public enum ClientTypes
{
    Company,
    Person,
}

public interface IClient
{
    ClientTypes ClientType { get; set; }
}
