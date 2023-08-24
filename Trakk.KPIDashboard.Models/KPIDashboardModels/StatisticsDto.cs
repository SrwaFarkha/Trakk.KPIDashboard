using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trakk.KPIDashboard.Models.KPIDashboardModels
{
    public class StatisticsDto
    {

        public int TotalAccounts { get; set; }
        public int TotalCustomers { get; set; }
        public int TotalLora { get; set; }
        public int TotalGsm { get; set;}
        public int TotalTrakkers { get; set;}
    }
}
