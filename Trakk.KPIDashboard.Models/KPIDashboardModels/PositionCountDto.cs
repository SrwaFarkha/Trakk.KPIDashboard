using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Trakk.KPIDashboard.Models.KPIDashboardModels
{
    public class PositionCountDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Count { get; set; }


    }
}
