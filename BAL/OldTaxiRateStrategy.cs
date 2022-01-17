using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OldTaxiRateStrategy : IRateStrategy
    {
        public double GetRates(List<double> rate, double baseFareDistance) => rate[4] - baseFareDistance;
    }
}
