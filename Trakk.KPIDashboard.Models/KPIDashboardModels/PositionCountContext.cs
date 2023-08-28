using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trakk.KPIDashboard.Models.KPIDashboardModels
{
    public class PositionCountContext
    {
        public int TotalPositions { get; set; }
        public List<PositionCountDto> PositionCount { get; set; }
    }
}
