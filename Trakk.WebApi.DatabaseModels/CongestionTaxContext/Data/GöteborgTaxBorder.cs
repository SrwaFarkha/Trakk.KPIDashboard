using System;
using System.Collections.Generic;
using System.Linq;
using CongestionTaxProcessor.Models.TaxAreas;
using NetTopologySuite.Geometries;

namespace CongestionTaxProcessor.Models;

public class GöteborgTaxBorder : ITaxBorder
{
    public static readonly Geometry Geometry = new Polygon(
        new LinearRing(new[]
        {
            new Coordinate { Y = 57.69935469580243, X = 11.918449401855469 },
            new Coordinate { Y = 57.70334470032475, X = 11.940808296203613 },
            new Coordinate { Y = 57.7073801198233, X = 11.937417984008789 },
            new Coordinate { Y = 57.70740304705843, X = 11.935186386108398 },
            new Coordinate { Y = 57.70815963767355, X = 11.93441390991211 },
            new Coordinate { Y = 57.71178188279439, X = 11.936173439025879 },
            new Coordinate { Y = 57.712056975212505, X = 11.941537857055662 },
            new Coordinate { Y = 57.71313440039105, X = 11.944198608398438 },
            new Coordinate { Y = 57.718566885676495, X = 11.954197883605955 },
            new Coordinate { Y = 57.72085882899512, X = 11.956729888916016 },
            new Coordinate { Y = 57.721133852440204, X = 11.95763111114502 },
            new Coordinate { Y = 57.72551102758325, X = 11.977200508117676 },
            new Coordinate { Y = 57.72690886202758, X = 11.978616714477537 },
            new Coordinate { Y = 57.72952106360986, X = 11.982264518737793 },
            new Coordinate { Y = 57.732843328223716, X = 11.983981132507324 },
            new Coordinate { Y = 57.73385140335699, X = 11.984796524047852 },
            new Coordinate { Y = 57.74515595803953, X = 11.988937854766846 },
            new Coordinate { Y = 57.74726300199903, X = 11.989173889160156 },
            new Coordinate { Y = 57.74793860422642, X = 11.989409923553467 },
            new Coordinate { Y = 57.74958747868863, X = 11.990418434143066 },
            new Coordinate { Y = 57.75113323019829, X = 11.990976333618164 },
            new Coordinate { Y = 57.752507176054095, X = 11.991147994995117 },
            new Coordinate { Y = 57.75623374125456, X = 11.991040706634521 },
            new Coordinate { Y = 57.757905132628245, X = 11.990708112716675 },
            new Coordinate { Y = 57.75804250382407, X = 11.98982834815979 },
            new Coordinate { Y = 57.758557641158035, X = 11.99004292488098 },
            new Coordinate { Y = 57.759009811210746, X = 11.989399194717407 },
            new Coordinate { Y = 57.75943335777395, X = 11.987961530685425 },
            new Coordinate { Y = 57.75903842937817, X = 11.989463567733763 },
            new Coordinate { Y = 57.75857481227604, X = 11.990128755569458 },
            new Coordinate { Y = 57.75807112275751, X = 11.989903450012207 },
            new Coordinate { Y = 57.75792802786382, X = 11.990718841552734 },
            new Coordinate { Y = 57.756216569024225, X = 11.99108362197876 },
            new Coordinate { Y = 57.75435619575176, X = 11.991105079650879 },
            new Coordinate { Y = 57.752507176054095, X = 11.991169452667236 },
            new Coordinate { Y = 57.75113323019829, X = 11.990987062454222 },
            new Coordinate { Y = 57.749581753560186, X = 11.990429162979126 },
            new Coordinate { Y = 57.74792715344638, X = 11.989420652389526 },
            new Coordinate { Y = 57.74726300199903, X = 11.989173889160156 },
            new Coordinate { Y = 57.74515595803953, X = 11.988948583602905 },
            new Coordinate { Y = 57.73384567573671, X = 11.98481798171997 },
            new Coordinate { Y = 57.73283473655355, X = 11.983997225761412 },
            new Coordinate { Y = 57.72947523713723, X = 11.982264518737793 },
            new Coordinate { Y = 57.72693177689646, X = 11.978702545166016 },
            new Coordinate { Y = 57.725488111814606, X = 11.977286338806152 },
            new Coordinate { Y = 57.72507562549749, X = 11.980161666870117 },
            new Coordinate { Y = 57.72392980550088, X = 11.983036994934082 },
            new Coordinate { Y = 57.7243881378533, X = 11.98458194732666 },
            //Marieholmstunneln
            new Coordinate { Y = 57.72261, X = 11.98741 },
            new Coordinate { Y = 57.72817, X = 11.99252 },
            new Coordinate { Y = 57.72809, X = 11.99326 },
            new Coordinate { Y = 57.72224, X = 11.98805 },
            //Slut Marieholmstunneln
            new Coordinate { Y = 57.721351577852026, X = 11.989002227783203 },
            new Coordinate { Y = 57.72059526289911, X = 11.991426944732666 },
            new Coordinate { Y = 57.71972433519276, X = 11.994473934173584 },
            new Coordinate { Y = 57.71840644420874, X = 11.994366645812988 },
            new Coordinate { Y = 57.717397938698106, X = 11.993529796600342 },
            new Coordinate { Y = 57.71627479721763, X = 11.996512413024902 },
            new Coordinate { Y = 57.71550691512778, X = 11.995267868041992 },
            new Coordinate { Y = 57.713845024981005, X = 11.995750665664673 },
            new Coordinate { Y = 57.71109414260419, X = 11.997692584991455 },
            new Coordinate { Y = 57.70288610147306, X = 11.995739936828613 },
            new Coordinate { Y = 57.70113190727805, X = 11.99533224105835 },
            new Coordinate { Y = 57.69878138317614, X = 11.995718479156494 },
            new Coordinate { Y = 57.6980933960466, X = 11.99681282043457 },
            new Coordinate { Y = 57.69742832940041, X = 11.99704885482788 },
            new Coordinate { Y = 57.69698112254847, X = 11.996469497680664 },
            new Coordinate { Y = 57.69266930661857, X = 11.99831485748291 },
            new Coordinate { Y = 57.69001430298987, X = 12.000911235809326 },
            new Coordinate { Y = 57.688391386397214, X = 12.00780987739563 },
            new Coordinate { Y = 57.689985630182576, X = 12.000889778137207 },
            new Coordinate { Y = 57.68889604669353, X = 12.00008511543274 },
            new Coordinate { Y = 57.68600562439742, X = 12.002670764923096 },
            new Coordinate { Y = 57.685271512182815, X = 11.999098062515259 },
            new Coordinate { Y = 57.68511092315363, X = 11.998293399810791 },
            new Coordinate { Y = 57.68026424088437, X = 11.993250846862793 },
            new Coordinate { Y = 57.683407488574815, X = 11.984034776687622 },
            new Coordinate { Y = 57.68129098862852, X = 11.978166103363037 },
            new Coordinate { Y = 57.68079769445953, X = 11.972157955169676 },
            new Coordinate { Y = 57.68272494518315, X = 11.970033645629883 },
            new Coordinate { Y = 57.68300025834997, X = 11.967029571533203 },
            new Coordinate { Y = 57.68144012275335, X = 11.965913772583006 },
            new Coordinate { Y = 57.67922599152547, X = 11.96986198425293 },
            new Coordinate { Y = 57.674372785264715, X = 11.953811645507812 },
            new Coordinate { Y = 57.677746004570096, X = 11.94114089012146 },
            new Coordinate { Y = 57.68137129169506, X = 11.943039894104004 },
            new Coordinate { Y = 57.697193259820395, X = 11.945732831954954 },
            new Coordinate { Y = 57.699176969858776, X = 11.936752796173096 },
            new Coordinate { Y = 57.69988213540432, X = 11.936173439025879 },
            new Coordinate { Y = 57.7001859829926, X = 11.936066150665283 },
            new Coordinate { Y = 57.70048409513029, X = 11.93861961364746 },
            new Coordinate { Y = 57.700994319826385, X = 11.944777965545654 },
            new Coordinate { Y = 57.70220965756704, X = 11.94838285446167 },
            new Coordinate { Y = 57.70336763011488, X = 11.940851211547852 },
            new Coordinate { Y = 57.69935469580243, X = 11.918578147888184 },
            new Coordinate { Y = 57.694951422063205, X = 11.908278465270996 },
            new Coordinate { Y = 57.69054761306947, X = 11.898107528686523 },
            new Coordinate { Y = 57.69935469580243, X = 11.918449401855469 }
        }));
    public GöteborgTaxBorder(TaxArea area, List<TariffPeriod> tariffPeriods)
    {
        TaxArea = area;
        TariffPeriods = tariffPeriods;
    }
    public TaxArea TaxArea { get; }
    public Enums.TaxBorder Id => Enums.TaxBorder.Göteborg;
    public List<TariffPeriod> TariffPeriods { get; set; }
    public Enums.Area Area => TaxArea.Id;
    public Geometry Bounds => Geometry;
    public Tariff? GetTariff(DateTime dateTime)
    {
        dateTime = dateTime.ToLocalTime();
        var season =
            TariffPeriods?.FirstOrDefault(x => x.ValidFrom <= dateTime && x.ValidTo >= dateTime) ??
            TariffPeriods?.OrderByDescending(x => x.ValidFrom)
                .FirstOrDefault(x => x.ValidFrom <= dateTime && !x.ValidTo.HasValue);
        return season?.GetTariff(TimeOnly.FromDateTime(dateTime));
    }

    public virtual List<PassageInput> GetPassages(IEnumerable<CoordinateLine> lines) =>
        lines.DistinctBy(x => x.CrossTime)
            .OrderBy(x => x.CrossTime)
            .Where(x => x.Crosses(Bounds))
            .SelectMany(t =>
            {
                var passages = new List<PassageInput>();
                if (Bounds.Contains(t.StartPoint) && Bounds.Contains(t.EndPoint) && !Bounds.Covers(t))
                {
                    var firstTariff = GetTariff(t.OriginalFirstTimeStamp);
                    var secondTariff = GetTariff(t.OriginalSecondTimeStamp);
                    passages.Add(new PassageInput
                    {
                        TaxBorder = Id, Area = Area, PassageTime = t.OriginalFirstTimeStamp, Cost = firstTariff?.Toll ?? 0,
                        Tariff = firstTariff,
                    });
                    passages.Add(new PassageInput
                    {
                        TaxBorder = Id, Area = Area, PassageTime = t.OriginalFirstTimeStamp, Cost = secondTariff?.Toll ?? 0,
                        Tariff = secondTariff,
                    });
                }
                else
                {
                    var tariff = GetTariff(t.CrossTime);
                    passages.Add(new PassageInput
                    {
                        TaxBorder = Id, Area = Area, PassageTime = t.CrossTime, Cost = tariff?.Toll ?? 0,
                        Tariff = tariff,
                    });
                }
                return passages;
            })   .Where(t => t.Tariff != null).ToList();
    
    
}