namespace TasksLab;
/// <summary>
/// Возможность отмены Task, через определенное время
/// </summary>
public class TaskCancel
{
    public static async Task Run()
    {
        try
        {
            var cts = new CancellationTokenSource();
            var task = ProcessCts(cancellationToken: cts.Token);
            // var task = Task.Run(() => ProcessCts(cancellationToken: cts.Token));
            await Task.Delay(2000);
            cts.Cancel();
            //await task;
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