using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trakk.KPIDashboard.Models.KPIDashboardModels
{
    public class PositionDto
    {
        public int Today { get; set; }
        public int Yesterday { get; set; }
        public int Earlier { get; set; }
    }
}
