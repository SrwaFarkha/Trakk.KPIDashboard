namespace Trakk.Utils.Helpers;

public class Switcheroo<TOutput>
{
    private readonly Dictionary<Predicate<object>, Func<object, TOutput>?> _cases = new();
    private Func<object, TOutput> _default = o => throw new NotImplementedException();
    public static Switcheroo<TOutput> New => new();

    public Switcheroo<TOutput> Default(TOutput output)
    {
        return Default(_ => output);
    }

    public Switcheroo<TOutput> Default(Func<object, TOutput> func)
    {
        _default = func;
        return this;
    }
    
    public TOutput this[object input] => Evaluate(input);

    public Switcheroo<TOutput> Case<TValue>(TOutput output) => Case(o => o is TValue, o => output);

    public Switcheroo<TOutput> Case<TValue>(Func<TValue, TOutput> func) => Case(o => o is TValue, o => func((TValue)o));

    public Switcheroo<TOutput> Case<TValue>(Predicate<TValue> condition, TOutput output) => Case(condition, o => output);

    public Switcheroo<TOutput> Case<TValue>(Predicate<TValue> condition, Func<TValue, TOutput> func) => Case(o => o is TValue value && condition(value), o => func((TValue)o));

    public Switcheroo<TOutput> Case(Predicate<object> condition, Func<object, TOutput> func)
    {
        _cases.Add(condition, func);
        return this;
    }

    public TOutput Evaluate(object input)
    {
        var key = _cases.Keys?.FirstOrDefault(x => x(input));

        return key != null ? _cases[key](input) : _default(input);
    }
}