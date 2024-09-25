// See https://aka.ms/new-console-template for more information

public class RandomCommand(DataSerivce dataSerivce)
{
    public void Execute()
    {
        Console.WriteLine(dataSerivce.AccountId);
    }
}