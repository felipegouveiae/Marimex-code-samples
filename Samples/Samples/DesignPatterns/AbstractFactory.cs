using Samples.Solid.OCP.Implementations;

namespace Samples.DesignPatterns;

public class BankAccountAbstractFactory
{
    public AbstractBankAccount CreateAccount(IClient client)
    {
        switch (client.ClientType)
        {
            case ClientTypes.Company:
                return new AbstractBankInvestingAccount();
            case ClientTypes.Person:
                return new AbstractBankCheckingAccount();
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
