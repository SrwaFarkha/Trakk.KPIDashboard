﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trakk.KPIDashboard.Models.KPIDashboardModels
{
    public class PositionDto
    {
        public int PositionCountToday { get; set; }
        public int PositionCountYesterday { get; set; }
        public int PositionCountEarlier { get; set; }
    }
}
