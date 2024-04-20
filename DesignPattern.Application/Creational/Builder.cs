namespace DesignPattern.Application.Creational.Builder;

#region Usage

static class Program
{
    static void Main()
    {
        var service = new BankingService();
        var danskeBankIndividualAccount = service.CreateIndividualAccount(new DanskeBankAccountBuilder());
        var creditBankCorporateAccount = service.CreateCorporateAccount(new CreditBankAccountBuilder());
    }
}

#endregion

#region Abstractions

public abstract class BaseAccountBuilder
{
    public abstract CorporateAccount BuildCorporateAccount();
    public abstract IndicidualAccount BuildIndicidualAccount();
}


#endregion

#region Models

public abstract class CorporateAccount
{
}

public abstract class IndicidualAccount
{
}

public class DanskeBankCorporateAccount : CorporateAccount
{

}

public class DanskeBankIndividualAccount : IndicidualAccount
{

}

public class CreditBankCorporateAccount : CorporateAccount
{

}

public class CreditBankIndividualAccount : IndicidualAccount
{

}


#endregion

#region Implementation

public class BankingService
{
    public CorporateAccount CreateCorporateAccount(BaseAccountBuilder builder)
    {
        return builder.BuildCorporateAccount();
    }

    public IndicidualAccount CreateIndividualAccount(BaseAccountBuilder builder)
    {
        return builder.BuildIndicidualAccount();
    }
}


public class DanskeBankAccountBuilder : BaseAccountBuilder
{
    public override CorporateAccount BuildCorporateAccount()
    {
        return new DanskeBankCorporateAccount();
    }

    public override IndicidualAccount BuildIndicidualAccount()
    {
        return new DanskeBankIndividualAccount();
    }
}


public class CreditBankAccountBuilder : BaseAccountBuilder
{
    public override CorporateAccount BuildCorporateAccount()
    {
        return new CreditBankCorporateAccount();
    }

    public override IndicidualAccount BuildIndicidualAccount()
    {
        return new CreditBankIndividualAccount();
    }
}


#endregion

