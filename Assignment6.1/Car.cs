using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6._1
{
    class Car
    {
        [Name("Model Year")]
        public int ModelYear { get; set; }

        [Name("Division")]
        public string Division { get; set; }

        [Name("Carline")]
        public string Carline { get; set; }

        [Name("Eng Displ")]
        public double EngDispl { get; set; }

        [Name("# Cyl")]
        public int Cylinders { get; set; }

        [Name("City FE")]
        public int CityFE { get; set; }

        [Name("Hwy FE")]
        public int HwyFE { get; set; }

        [Name("Comb FE")]
        public int CombinedFE { get; set; }
    }
}
