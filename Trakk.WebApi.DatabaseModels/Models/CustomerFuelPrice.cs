using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trakk.WebApi.Models;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class CustomerFuelPrice : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedOn { get; set; }
        public double Petrol{ get; set; }
        public double Diesel { get; set; }
        public double E85 { get; set; }
        public double Electric { get; set; }
        public double Gas { get; set; }
        public double Hvo100 { get; set; }
        public virtual Customer Customer { get; set; } = null!;

        public double GetPrice(Enums.FuelType type) => type switch
        {
            Enums.FuelType.Diesel => Diesel,
            Enums.FuelType.E85 => E85,
            Enums.FuelType.Electric => Electric,
            Enums.FuelType.Gas => Gas,
            Enums.FuelType.Petrol => Petrol,
            Enums.FuelType.Hvo100 => Hvo100,
            _ => 0
        };
    }
}
