namespace DesignPattern.Application.Structural.Decorator;

// Attaches additional responsibilities to an object dynamically

#region Usage

static class Program
{
    static void Main()
    {
        var account = new DanskeBankIndividualAccount();
        var orderableAccount = new DanskeBankOrderableAccount(account);
        orderableAccount.Buy();
    }
}

#endregion

#region Models

// Component
public abstract class IndicidualAccount
{
}

// Concrete component
public class DanskeBankIndividualAccount : IndicidualAccount
{

}

// Abstract decorator
public abstract class OrderableAccount : IndicidualAccount
{

    protected IndicidualAccount _account;

    protected OrderableAccount(IndicidualAccount account)
    {
        _account = account;
    }

    public abstract void Buy();
}

#endregion

#region Implementation

// Concrete decorator
public class DanskeBankOrderableAccount : OrderableAccount
{
    public DanskeBankOrderableAccount(IndicidualAccount account) : base(account)
    {
    }

    public override void Buy()
    {
        // TODO: business logic here...
        Log();
    }

    public void Log()
    {
        Console.WriteLine("Someone is buying Danske Bank account");
    }
}

#endregion
