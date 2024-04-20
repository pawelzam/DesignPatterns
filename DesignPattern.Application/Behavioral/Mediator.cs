namespace DesignPattern.Application.Behavioral.Mediator;

#region Usage

static class Program
{
    static void Main()
    {
        var mediator = new Mediator();
        mediator.Send(new CreateAccountCommand());
        mediator.Send(new CreateCustomerCommand());
    }
}

#endregion

public abstract class Command
{    
}

public abstract class CommandHandler
{
    public abstract void Handle(Command command);
}

public class CreateAccountCommand : Command { }

public class CreateCustomerCommand : Command { }

public class CreateAccountCommandHandler : CommandHandler
{
    public override void Handle(Command command)
    {
        Console.WriteLine(this.GetType().Name);
    }
}

public class CreateCustomerCommandHandler : CommandHandler
{
    public override void Handle(Command command)
    {
        Console.WriteLine(this.GetType().Name);
    }
}

public class Mediator
{
    public void Send(Command command)
    {
        if (command is CreateAccountCommand)
        {
            new CreateAccountCommandHandler().Handle(command);
            return;
        }

        if (command is CreateCustomerCommand)
        {
            new CreateCustomerCommandHandler().Handle(command);
            return;
        }
    }
}
