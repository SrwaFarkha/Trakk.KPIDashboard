using System;
using System.Collections.Generic;
using System.Linq;

namespace Trakk.WebApi.DatabaseModels.Models.UserEvents;

public class TypeHelper
{
    public static int GetObjectId<TObj>(TObj obj)
    {
        return obj switch
        {
            _ => FindId(obj)
        };
    }

    private static int FindId<TObj>(TObj obj)
    {
        var props = typeof(TObj).GetProperties();
        var matches = new[] { "Id", obj.GetType().Name + "Id" };
        var prop = props.FirstOrDefault(x => matches.Contains(x.Name))
                   ?? throw new NullReferenceException($"No Id was found for {obj.GetType().Name}");

        return (int)prop.GetValue(obj);
    }
}