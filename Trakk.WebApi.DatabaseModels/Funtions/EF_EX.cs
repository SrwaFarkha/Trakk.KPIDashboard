using System;
using NetTopologySuite.Geometries;

namespace Trakk.WebApi.DatabaseModels.Funtions;

public static class EF_EX
{
    public static TimeSpan TimeDiff(DateTime from, DateTime to) => throw new NotSupportedException();
    public static double TimeToSec(TimeSpan ts) => throw new NotSupportedException();
    public static DateTime ConvertTz(DateTime dt, string from_tz, string to_tz) => throw new NotSupportedException();
    public static Point CreatePoint(double lng, double lat) => throw new NotSupportedException();
    public static Point SRID(Point point, int srid = 4326 ) => throw new NotSupportedException();
}