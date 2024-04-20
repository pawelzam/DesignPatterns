namespace DesignPattern.Application.Creational.Prototype;

#region Usage

static class Program
{
    static void Main()
    {
        var danskeBankAccountPrototype = new DanskeBankCorporateAccount("Danske Bank Corporate Account");
        var danskeBankAccount = danskeBankAccountPrototype.Clone();
        danskeBankAccount.AssignCustomer("ACME CO.");

        var creaditBankAccount = new CreditBankCorporateAccount("Credit Bank Corporate Account");
        var creditBankAccount = creaditBankAccount.Clone();
        creditBankAccount.AssignCustomer("ACME CO.");
    }
}

#endregion


#region Models

public abstract class CorporateAccount
{
    public string Name { get; set; }
    public string Number { get; set; } = Guid.Empty.ToString();

    protected CorporateAccount(string name)
    {
        Name = name;
    }

    public abstract void AssignCustomer(string customerName);

    public abstract CorporateAccount Clone();
}


public class DanskeBankCorporateAccount : CorporateAccount
{
    public DanskeBankCorporateAccount(string name) : base(name)
    {
    }

    public override void AssignCustomer(string customerName)
    {
        Number = Guid.NewGuid().ToString();
    }

    public override CorporateAccount Clone()
    {
        return (CorporateAccount)this.MemberwiseClone();
    }
}


public class CreditBankCorporateAccount : CorporateAccount
{
    public CreditBankCorporateAccount(string name) : base(name)
    {
    }

    public override void AssignCustomer(string customerName)
    {
        Number = Guid.NewGuid().ToString();
    }

    public override CorporateAccount Clone()
    {
        return (CorporateAccount)this.MemberwiseClone();
    }
}


#endregion