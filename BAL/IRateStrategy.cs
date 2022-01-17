using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IRateStrategy
    {
        double GetRates(List<double> rate, double baseFareDistance);
    }
}
