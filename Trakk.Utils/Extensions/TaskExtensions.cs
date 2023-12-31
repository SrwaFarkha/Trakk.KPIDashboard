namespace Trakk.Utils.Extensions;

public static class TaskExtensions
{
    public static async Task<TResult> TimeoutAfter<TResult>(this Task<TResult> task, TimeSpan timeout)
    {
        using var timeoutCancellationTokenSource = new CancellationTokenSource();
        
        var completedTask = await Task.WhenAny(task, Task.Delay(timeout, timeoutCancellationTokenSource.Token));
        if (completedTask != task) throw new TimeoutException("The operation has timed out.");
        timeoutCancellationTokenSource.Cancel();
        return await task;  // Very important in order to propagate exceptions

    }
    
    public static async Task TimeoutAfter(this Task task, TimeSpan timeout)
    {
        using var timeoutCancellationTokenSource = new CancellationTokenSource();
        
        var completedTask = await Task.WhenAny(task, Task.Delay(timeout, timeoutCancellationTokenSource.Token));
        if (completedTask != task) throw new TimeoutException("The operation has timed out.");
        timeoutCancellationTokenSource.Cancel();
        await task;  // Very important in order to propagate exceptions
    }
}