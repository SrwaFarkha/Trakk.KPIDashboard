using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Trakk.Utils.Extensions.StringExtensions;

namespace Trakk.WebApi.DatabaseModels.Models.UserEvents;

public enum UserEventType
{
    Login,
    PropertyChanged
}

public abstract class UserEvent
{
    public int Id { get; set; }
    public UserEventType EventType { get; set; }
    public int AccountId { get; set; }
    public string IpAddress { get; set; }
    public DateTime TimeStamp { get; set; }
}
public class UserLoginEvent : UserEvent
{
    public override string ToString() => $"Account {AccountId} logged in from {IpAddress} at {TimeStamp}";
}

public class UpdatedProperty
{
    public string Type { get; set; }
    public string Name { get; set; }
    public object Previous { get; set; }
    public object Updated { get; set; }
    public static UpdatedProperty Create<TProperty>(string propertyName, TProperty previousValue, TProperty updatedValue)
    {
        return new UpdatedProperty()
        {
            Name = propertyName,
            Type = typeof(TProperty).Name,
            Previous = previousValue,
            Updated = updatedValue
        };
    }
    public override string ToString() => $"'{Name}': '{Previous}' => '{Updated}'";
}

public class UpdatePropertiesUserEvent : UserEvent
{
    public string TargetType { get; set; }
    public int TargetId { get; set; }
    public List<UpdatedProperty> Properties { get; set; } = new List<UpdatedProperty>();
    public override string ToString() => 
        $"Account '{AccountId}' updated {TargetType} '{TargetId}' : {string.Join(", ", Properties.Select(x => x.ToString()))} ";
}
