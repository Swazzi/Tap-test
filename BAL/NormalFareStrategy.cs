using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NormalFareStrategy : IBillingStrategy
    {
        
        public double GetFarePrice(double fare, double rate) => fare + rate;
    }
}
