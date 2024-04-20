
namespace DesignPattern.Application.Creational.FactoryMethod;

#region Usage

static class Program
{
    static void Main()
    {
        var factories = new IndividualAccountFactory[]
        {
            new DanskeBankAccountFactory(),
            new CreditBankAccountFactory(),
        };

        foreach (var factory in factories)
        {
            var account = factory.BuildIndicidualAccount();
            Console.WriteLine($"Created {account.GetType().Name}");
        }
    }
}

#endregion

#region Abstractions

public abstract class IndividualAccountFactory
{
    public abstract IndicidualAccount BuildIndicidualAccount();
}


#endregion


#region Models

public abstract class IndicidualAccount
{
}


public class DanskeBankIndividualAccount : IndicidualAccount
{

}

public class CreditBankIndividualAccount : IndicidualAccount
{

}


#endregion

#region Implementation

public class DanskeBankAccountFactory : IndividualAccountFactory
{
    public override IndicidualAccount BuildIndicidualAccount()
    {
        return new DanskeBankIndividualAccount();
    }
}

public class CreditBankAccountFactory : IndividualAccountFactory
{
    public override IndicidualAccount BuildIndicidualAccount()
    {
        return new CreditBankIndividualAccount();
    }
}

#endregion
