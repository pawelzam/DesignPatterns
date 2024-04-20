namespace DesignPattern.Application.Structural.Bridge;

// Decouples an abstraction from its implementation so that the two can vary independently. 

#region Usage

static class Program
{
    static void Main()
    {
        var accountService = new AccountService(new DanskeBankAccountCreator());
        var danskeBankAccount = accountService.CreateAccount();

        Console.WriteLine(danskeBankAccount.GetType().Name);

        accountService = new AccountService(new CreditBankAccountCreator());
        var creditBankAccount = accountService.CreateAccount();

        Console.WriteLine(creditBankAccount.GetType().Name);
    }
}

#endregion

#region Models

public abstract class IndicidualAccount
{
}

public class DanskeBankIndividualAccount: IndicidualAccount
{

}

public class CreditBankIndividualAccount : IndicidualAccount
{

}

#endregion


#region Abstrations

// Abstraction
public abstract class BaseAccountService(BaseAccountCreator implementor)
{
    private readonly BaseAccountCreator _implementor = implementor;

    public virtual IndicidualAccount CreateAccount()
    {
        return _implementor.CreateAccount();
    }
}

// Implementor
public abstract class BaseAccountCreator
{
    public abstract IndicidualAccount CreateAccount();
}

#endregion

#region Implementation

// Refined abstraction
public class AccountService(BaseAccountCreator implementor) : BaseAccountService(implementor)
{
}


// Concrete implementor 1
public class DanskeBankAccountCreator : BaseAccountCreator
{
    public override IndicidualAccount CreateAccount()
    {
        return new DanskeBankIndividualAccount();
    }
}

// Concrete implementor2
public class CreditBankAccountCreator : BaseAccountCreator
{
    public override IndicidualAccount CreateAccount()
    {
        return new CreditBankIndividualAccount();
    }
}

#endregion