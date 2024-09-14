namespace DesignPattern.Application.Creational.AbstractFactory;

#region Usage

static class Program
{
    static void Main()
    {
        var factory = new DanskeBankAccountFactory();
        var corporateAccount = factory.CreateCorporateAccount();
        var individualAccount = factory.CreateIndividualAccount();
    }
}

#endregion

#region Abstractions
public abstract class BaseAccountFactory
{
    public abstract CorporateAccount CreateCorporateAccount();
    public abstract IndividualAccount CreateIndividualAccount();
}

public abstract class CorporateAccount
{
}

public abstract class IndividualAccount
{
}

#endregion

#region Implementation

public class DanskeBankCorporateAccount : CorporateAccount
{

}

public class DanskeBankIndividualAccount : IndividualAccount
{

}

public class DanskeBankAccountFactory : BaseAccountFactory
{
    public override CorporateAccount CreateCorporateAccount()
    {
        return new DanskeBankCorporateAccount();
    }

    public override IndividualAccount CreateIndividualAccount()
    {
        return new DanskeBankIndividualAccount();
    }
}

#endregion

