namespace TasksLab;

public class TaskCancel
{
    public static async Task Run()
    {
        var cts = new CancellationTokenSource();
        var task = Task.Run(() => ProcessCts(cancellationToken: cts.Token));
    
        Task.Delay(2000).GetAwaiter().GetResult();
        cts.Cancel();
        try
        {
            await task;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Canceled");
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed");
        }
    }


    static async Task ProcessCts(CancellationToken cancellationToken)
    {

        for (var i = 0;; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();
            Console.WriteLine($"work {i}");
            await Task.Delay(TimeSpan.FromSeconds(0.5), cancellationToken);
        }
    }
}