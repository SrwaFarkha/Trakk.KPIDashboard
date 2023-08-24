using NLog;

namespace Trakk.Utils.Extensions.EnumerableExtensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<TSource> Reduce<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, TSource, bool> func)
        {
            var keeping = new List<TSource>();
            using var enumerator = source.GetEnumerator();
            enumerator.MoveNext();
            var source1 = enumerator.Current;
            enumerator.MoveNext();
            var source2 = enumerator.Current;
            while (enumerator.MoveNext())
            {
                if (func(source1, source2, enumerator.Current)) keeping.Add(source2);
                source1 = source2;
                source2 = enumerator.Current;
            }
            return keeping;
        }
        public static IEnumerable<T> JoinMulti<T>(this  IEnumerable<T> src, params IEnumerable<T>[] otherArrays)
        {
            return otherArrays.Aggregate(src, (current, arr) => current.Concat(arr));
        }

        public static LinkedList<T> ToLinkedList<T>(this IEnumerable<T> src)
        {
            return new LinkedList<T>(src);
        }

        public static LinkedListNode<T>? FirstOrDefaultNode<T>(this LinkedList<T> src, Func<T, bool> condition)
        {
            var current = src.First;
            while (current != null)
            {
                if(condition(current.Value))
                { return current; }
                current = current.Next;
            }
            return null;
        }

        private static void HandleException(object o, Exception exception)
        {
            var logger = LogManager.GetLogger(o.GetType().FullName);
                logger.Error(exception);
        }
        public static void TryForEach<T>(this IEnumerable<T> value, Action<T> action, Action<object,Exception> onError)
        {
            foreach (var v in value)
                try
                {
                    action(v);
                }
                catch (Exception e)
                {
                    onError?.Invoke(v, e);
                }
        }
        public static void TryForEach<T>(this IEnumerable<T> value, Action<T> action)
        {
            TryForEach(value, action, HandleException);
        }
        public static void ForEach<T>(this IEnumerable<T> value, Action<T> action)
        {
            foreach (var v in value)
                action(v);
        }
        
        public static Task TryForEachAsync<T>(this IEnumerable<T> collection, Func<T,Task> func, Action<object,Exception> onError)
        {
            var tasks = collection.Select(x =>
            {
                return Task.Run(() =>
                {
                    try
                    {
                        return func(x);
                    }
                    catch (Exception e)
                    {
                        onError.Invoke(x, e);
                        return Task.FromResult(0);
                    }
                });

            } );
            return Task.WhenAll(tasks);
        }
        public static Task TryForEachAsync<T>(this IEnumerable<T> collection, Func<T,Task> func)
        {
            return TryForEachAsync(collection, func, HandleException);
        }
        public static Task ForEachAsync<T>(this IEnumerable<T> collection, Func<T, Task> func)
        {
            var tasks = collection.Select(x => Task.Run(() =>func(x)));
            return Task.WhenAll(tasks);
        }

        public static bool Exists<T>(this IEnumerable<T> value, Predicate<T> predicate)
        {
            return value.Any(v => predicate(v));
        }
        
        public static async Task ForEachAsyncSemaphore<T>(this IEnumerable<T> source,
            int degreeOfParallelism, Func<T, Task> taskFunc)
        {
            var tasks = new List<Task>();
            using var throttler = new SemaphoreSlim(degreeOfParallelism);
            foreach (var element in source)
            {
                await throttler.WaitAsync();
                tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        await taskFunc(element);
                    }
                    finally
                    {
                        throttler.Release();
                    }
                }));
            }
            await Task.WhenAll(tasks);
        }

        public static async Task<List<T1>> ForEachAsyncSemaphore<T,T1>(this IEnumerable<T> source,
            int degreeOfParallelism, Func<T, Task<T1>> taskFunc)
        {
            var tasks = new List<Task<T1>>();
            using var throttler = new SemaphoreSlim(degreeOfParallelism);
            foreach (var element in source)
            {
                await throttler.WaitAsync();
                tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        return await taskFunc(element);
                    }
                    finally
                    {
                        throttler.Release();
                    }
                }));
            }
            await Task.WhenAll(tasks);

            return tasks.Select(x => x.Result).ToList();
        }

    }
}
