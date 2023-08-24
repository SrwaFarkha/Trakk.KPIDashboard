using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Trakk.WebApi.DatabaseModels.Converters;

public class EnumValueConverter<TEnum> : ValueConverter<ICollection<TEnum>, string?> where TEnum: struct
{
    public EnumValueConverter() : base(
            e => string.Join(",", e),
            e => (e??"").Split(",", StringSplitOptions.RemoveEmptyEntries).Select(Enum.Parse<TEnum>).ToList() )
        {
        }
    
}