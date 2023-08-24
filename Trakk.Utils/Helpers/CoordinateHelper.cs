using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trakk.Utils.Helpers
{
    public static class CoordinateHelper
    {
        public static bool IsCorrectCoordinate(decimal? longitude, decimal? latitude)
        {
            //Latitude or Longitude missing 
            if (longitude == null || latitude == null)
                return false;

            //Latitude outside range from +90 to -90 
            if (latitude is < -90 or > 90)
                return false;

            //Longitude outside range from +180 to -180
            if (longitude is < -180 or > 180)
                return false;

            //Default coordinate not ok
            if (latitude == 0 && longitude == 0)
                return false;

            return true;
        }
    }
}
