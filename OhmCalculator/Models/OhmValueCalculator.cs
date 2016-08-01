using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OhmCalculator.Models
{
    public class OhmValueCalculator : IOhmValueCalculator
    {
        public IEnumerable<Band> Bands { get; set; }

        public OhmValueCalculator() {
            Bands = new List<Band>
            {
                new Band { ColorName="Black", SignificantFigure=0, Multiplier=0 },
                new Band { ColorName="Brown", SignificantFigure=1, Multiplier=1, Tolerance=1 },
                new Band { ColorName="Red", SignificantFigure=2, Multiplier=2, Tolerance=2 },
                new Band { ColorName="Orange", SignificantFigure=3, Multiplier=3 },
                new Band { ColorName="Yellow", SignificantFigure=4, Multiplier=4, Tolerance=5 },
                new Band { ColorName="Green", SignificantFigure=5, Multiplier=5, Tolerance=0.5 },
                new Band { ColorName="Blue", SignificantFigure=6, Multiplier=6, Tolerance=0.25 },
                new Band { ColorName="Violet", SignificantFigure=7, Multiplier=7, Tolerance=0.1 },
                new Band { ColorName="Gray", SignificantFigure=8, Multiplier=8, Tolerance=0.05 },
                new Band { ColorName="White", SignificantFigure=9, Multiplier=9 },
                new Band { ColorName="Gold", Multiplier=-1, Tolerance=5 },
                new Band { ColorName="Silver", Multiplier=-2, Tolerance=10 },
                new Band { ColorName="None", SignificantFigure=0, Multiplier=0, Tolerance=20 }
            };
        }

        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            Band bandA = Bands.FirstOrDefault(band => band.ColorName == bandAColor);
            Band bandB = Bands.FirstOrDefault(band => band.ColorName == bandBColor);
            Band bandC = Bands.FirstOrDefault(band => band.ColorName == bandCColor);
            Band bandD = Bands.FirstOrDefault(band => band.ColorName == bandDColor);

            int digit1 = bandA != null ? bandA.SignificantFigure.Value : 0;
            int digit2 = bandB != null ? bandB.SignificantFigure.Value : 0;
            int multiplier = bandC != null ? bandC.Multiplier.Value : 0;
            double tolerance = bandD != null ? bandD.Tolerance.Value : 20;

            return (digit1 * 10 + digit2) * (int)Math.Pow(10, multiplier);
        }
    }

    public class Band
    {
        public string ColorName { get; set; }
        public int? SignificantFigure { get; set; }
        public int? Multiplier { get; set; }
        public double? Tolerance { get; set; }
    }
}