namespace DesignPattern.Application.Creational.AbstractFactory;

#region Usage

static class Program
{
    static void Main()
    {
        var factory = new DanskeBankAccountFactory();
        var corporateAccount = factory.CreateCorporateAccount();
        var individualAccount = factory.CreateIndicidualAccount();
    }
}

#endregion

#region Abstractions
public abstract class BaseAccountFactory
{
    public abstract CorporateAccount CreateCorporateAccount();
    public abstract IndicidualAccount CreateIndicidualAccount();
}

public abstract class CorporateAccount
{
}

public abstract class IndicidualAccount
{
}

#endregion

#region Implementation

public class DanskeBankCorporateAccount : CorporateAccount
{

}

public class DanskeBankIndividualAccount : IndicidualAccount
{

}

public class DanskeBankAccountFactory : BaseAccountFactory
{
    public override CorporateAccount CreateCorporateAccount()
    {
        return new DanskeBankCorporateAccount();
    }

    public override IndicidualAccount CreateIndicidualAccount()
    {
        return new DanskeBankIndividualAccount();
    }
}

#endregion

