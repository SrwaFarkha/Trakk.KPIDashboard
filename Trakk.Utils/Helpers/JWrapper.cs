using Newtonsoft.Json.Linq;

namespace Trakk.Utils.Helpers;

public class JWrapper
{
    public JWrapper(JToken? root)
    {
        Root = root;
    }
    public JToken? Root { get; }
    public T? PathGet<T>(string path, char separator = '.') => Get<T>(path.Split(separator).ToArray());
    
    public bool PathTryGet<T>(string path, out T? value, char separator = '.') => TryGet(out value, path.Split(separator).ToArray());
    public T? Get<T>(params string[] keys)
    {
        var token = Root?.SelectToken(string.Join(".", keys));

        return token switch
        {
            not null => token.Value<T>(),
            _ => default,
        };
    }
    
    public bool TryGet<T>(out T? result, params string[] keys)
    {
        result = default;
        try
        {
            var token = Root?.SelectToken(string.Join(".", keys));
            if (token == null) return false;
            result = token.Value<T>();
            return true;
        }
        catch
        {
            return false;
        }

    }

    public JWrapper SubWrapper(params string[] keys)
    {
        return new JWrapper(Root?.SelectToken(string.Join(".", keys)));
    }

    public bool HasPath(params string[] keys)
    {
        var jToken = Root?.SelectToken(string.Join(".", keys));

        return jToken != null;
    }
    
    /// <summary>
    /// Search for a token path and return last token in provided path if found.
    /// </summary>
    public bool TryFindPath(string path, out JToken? result, char separator = '.')
    {
        result = InternalFind(Root, path.Split(separator));
        return result != null;
    }
    /// <summary>
    /// Search for a token path and return last (T)token in provided path if found.
    /// </summary>
    public bool TryFindPath<T>(string path, out T? result,  char separator = '.')
    {
        result = InternalFind(Root, path.Split(separator)).Value<T>() ?? default;
        return result != null;
    }

    private JToken? InternalFind(JToken jToken, params string[] keys)
    {
        return jToken.Children().Select(jChild => jChild.SelectToken(string.Join(".", keys)) 
                                                  ?? InternalFind(jChild, keys))
            .FirstOrDefault(result => result != null);
    }

    public bool IsEmpty => Root is null || !Root.HasValues;
}