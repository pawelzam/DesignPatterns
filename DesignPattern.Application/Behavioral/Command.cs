namespace DesignPattern.Application.Behavioral.Command;

#region Usage

static class Program
{
    static void Main()
    {
        var createAccountCommand = new CreateAccountCommand(new CreateAccountCommandHandler());
        var invoker = new Invoker(createAccountCommand);
        invoker.ExecuteCommand();
    }
}

#endregion

#region Abstraction

public abstract class Command(CommandHandler handler)
{
    protected CommandHandler Handler { get; } = handler;

    public abstract void Execute();
}

public abstract class CommandHandler
{
    public abstract void Handle(Command command);
}

#endregion

#region Implementation

public class CreateAccountCommand(CreateAccountCommandHandler handler) : Command(handler)
{
    public override void Execute()
    {
        Handler.Handle(this);
    }
}

public class CreateAccountCommandHandler : CommandHandler
{
    public override void Handle(Command command)
    {
        // Business logic
    }
}

public class Invoker(Command command)
{
    private Command _command = command;
    public void ExecuteCommand()
    {
        _command.Execute();
    }
}

#endregion