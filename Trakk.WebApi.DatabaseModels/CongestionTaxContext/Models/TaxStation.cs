using NetTopologySuite.Geometries;

namespace CongestionTaxProcessor.Models;

public enum Direction
{
    N,
    E,
    S,
    W,
    NE,
    SE,
    SW,
    NW
}

public class TaxStation
{
    public int Number { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public Enums.TaxBorder TaxBorder { get; set; }
    public Direction Direction { get; set; }
    public string CpId { get; set; }
    public int? Lane { get; set; }
    public Coordinate Coordinate { get; set; }
}