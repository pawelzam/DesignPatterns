namespace DesignPattern.Application.Structural.Adapter;

#region Usage

static class Program
{
    static void Main()
    {
        var danskeBankCorporateAccount = new DanskeBankCorporateAccountAdapter("ACME CO", Guid.NewGuid().ToString());
        var danskeBankIndividualAccount = new DanskeBankIndividualAccountAdapter("Jan", "Dzban", Guid.NewGuid().ToString());

        var details = new[] 
        {
            danskeBankCorporateAccount.GetDetails(),
            danskeBankIndividualAccount.GetDetails()
        };

        foreach (var accountDetails in details)
        {
            Console.WriteLine(accountDetails);
        }
    }
}

#endregion

#region Models

public class AccountDetails
{
    public string Name { get; set; }
    public string Number { get; set; }

    public override string ToString()
    {
        return $"{Name} {Number}";
    }
}

public abstract class DanskeBankCorporateAccount
{
    public DanskeBankCorporateAccount(string name, string number)
    {
        CorporateCustomerName = name;
        Number = number;
    }

    public string CorporateCustomerName { get; set; }
    public string Number { get; set; }
}

public abstract class DanskeBankIndividualAccount
{
    protected DanskeBankIndividualAccount(string firstName, string lastName, string number)
    {
        FirstName = firstName;
        LastName = lastName;
        Number = number;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Number { get; set; } = Guid.Empty.ToString();
}

public class DanskeBankCorporateAccountAdapter : DanskeBankCorporateAccount
{
    public DanskeBankCorporateAccountAdapter(string name, string number) : base(name, number)
    {
    }

    public AccountDetails GetDetails()
    {
        return new AccountDetails
        {
            Name = CorporateCustomerName,
            Number = Number,
        };
    }
}

public class DanskeBankIndividualAccountAdapter : DanskeBankIndividualAccount
{
    public DanskeBankIndividualAccountAdapter(string firstName, string lastName, string number) : base(firstName, lastName, number)
    {
    }

    public AccountDetails GetDetails()
    {
        return new AccountDetails
        {
            Name = $"{FirstName} {LastName}",
            Number = Number,
        };
    }
}


#endregion
