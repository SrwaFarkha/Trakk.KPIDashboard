using System.Collections.Generic;
using Trakk.WebApi.Models;

namespace Trakk.WebApi.DatabaseModels.Models;

public class CustomerFeature
{
    public Enums.CustomerFeature Id { get; set; }
    public string Name { get; set; }
    public ICollection<Customer> Customers { get; set; }
    public ICollection<RightType> AccountRights { get; set; }
}

public class CustomerFeatureAccountRightMap
{
    public Enums.CustomerFeature CustomerFeatureId { get; set; }
    public CustomerFeature CustomerFeature { get; set; }
    public Enums.AccountRight AccountRightId { get; set; } 
    public RightType AccountRight { get; set; }
}

public class CustomerFeatureMap
{
    public Enums.CustomerFeature CustomerFeatureId { get; set; }
    public CustomerFeature CustomerFeature { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}