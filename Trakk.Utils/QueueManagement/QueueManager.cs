using System.Runtime.InteropServices;

namespace Trakk.Utils.QueueManagement;

using System.Collections.Concurrent;

public class QueueManager<TKey> where TKey : notnull
{
    private readonly ConcurrentDictionary<TKey, TaskQueue> _queues = new();
    /// <summary>
    /// Adds task to queue. If no queue exists on given key a new queue will be created. 
    /// </summary>
    /// <param name="key">Index of queue.</param>
    /// <param name="taskFunc">function to create task.</param>
    /// <returns>Value of completed task</returns>
    public TaskQueue this[TKey index]
    {
        get
        {
            lock (index)
            {
                if (!_queues.ContainsKey(index))
                    while (!_queues.TryAdd(index, new TaskQueue())) { }

                return _queues[index];
            }
        }
    }
    /// <summary>
    /// Adds task to queue. If no queue exists on given key a new queue will be created. 
    /// </summary>
    /// <param name="key">Index of queue.</param>
    /// <param name="taskFunc">function to create task.</param>
    /// <returns>Value of completed task</returns>
    public Task<T> Enqueue<T>(TKey key, Func<Task<T>> taskFunc)
    {
        return this[key].Enqueue(taskFunc);
    }

    public Task Enqueue(TKey key, Func<Task> taskGenerator)
    {
        return this[key].Enqueue(taskGenerator);
    }
}
public sealed class TaskQueue
{
    private readonly SemaphoreQueue _executeQueue;

    public TaskQueue(int concurrent = 1)
    {
        _executeQueue = new SemaphoreQueue(concurrent);
    }

    public Task<T> Enqueue<T>(Func<T> actionGenerator)
    {
        return Enqueue(() => Task.Run(actionGenerator));
    }
    public Task Enqueue(Action actionGenerator)
    {
        return Enqueue(() => Task.Run(actionGenerator));
    }
    public async Task<T> Enqueue<T>(Func<Task<T>> taskGenerator)
    {
        await _executeQueue.WaitAsync();
        try
        {
            return await taskGenerator();
        }
        finally
        {
            _executeQueue.Release();
        }
    }

    public async Task Enqueue(Func<Task> taskGenerator)
    {
        await _executeQueue.WaitAsync();
        try
        {
            await taskGenerator();
        }
        finally
        {
            _executeQueue.Release();
        }
    }
}
// https://stackoverflow.com/questions/23415708/how-to-create-a-fifo-strong-semaphore
public class SemaphoreQueue
{
    private readonly ConcurrentQueue<TaskCompletionSource<bool>> _queue = new();

    private readonly SemaphoreSlim _semaphore;

    public SemaphoreQueue(int initialCount)
    {
        _semaphore = new SemaphoreSlim(initialCount);
    }

    public SemaphoreQueue(int initialCount, int maxCount)
    {
        _semaphore = new SemaphoreSlim(initialCount, maxCount);
    }

    public void Wait()
    {
        WaitAsync().Wait();
    }

    public Task WaitAsync()
    {
        var tcs = new TaskCompletionSource<bool>();
        _queue.Enqueue(tcs);
        _semaphore.WaitAsync().ContinueWith(t =>
        {
            if (_queue.TryDequeue(out var popped))
                popped.SetResult(true);
        });
        return tcs.Task;
    }

    public void Release()
    {
        _semaphore.Release();
    }
}