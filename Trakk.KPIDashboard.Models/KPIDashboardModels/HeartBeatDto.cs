﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trakk.KPIDashboard.Models.KPIDashboardModels
{
    public class HeartBeatDto
    {
        public int HeartBeatCountToday { get; set; }
        public int HeartBeatCountYesterday { get; set; }
        public int HeartBeatCountEarlier { get; set; }

    }
}
