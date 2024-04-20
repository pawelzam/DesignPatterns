namespace DesignPattern.Application.Creational.Singleton;

#region Usage

static class Program
{
    static void Main()
    {
        var repository = Repository.Instance();
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(repository.Guid);
            repository = Repository.Instance();
        }
    }
}

#endregion

#region Implementation

public class Repository
{
    static Repository _instance = null!;
    private static object _locker = new ();

    private Repository(Guid guid)
    {
        Guid = guid;
    }

    public Guid Guid { get; }

    public static Repository Instance()
    {
        if (_instance == null)
        {
            lock (_locker)
            {
                _instance ??= new Repository(Guid.NewGuid());
            }
        }

        return _instance;
    }
}

#endregion