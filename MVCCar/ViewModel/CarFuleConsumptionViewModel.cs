using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCar.ViewModel
{
    public class CarFuleConsumptionViewModel
    {
        public string Make { get; set; }
        public string Mode { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public double TccRating { get; set; }
        public int MPG { get; set; }
        public double Distance { get; set; }
        public double FuleConsumption { get; set; }
    }
}
