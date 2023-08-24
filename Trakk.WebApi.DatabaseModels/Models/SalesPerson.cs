using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class SalesPerson : IEntity
    {
        public int SalesPersonId { get; set; }

        [Required]
        public string Name { get; set; }
        public int? CustomerAdminId { get; set; }

        public virtual CustomerAdmin CustomerAdmin { get; set; }
        public virtual List<Customer> Customers { get; set; } 
    }
}
