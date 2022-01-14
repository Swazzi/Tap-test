using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    interface IVehicle
    {
        List<Vehicle> GetVehicle();
        void AddVehicle();
        Vehicle UpdateVehicle(int userID, List<Vehicle> listVehicle);
        Vehicle DeleteVehicle(int userID, List<Vehicle> listVehicle);
        List<double> GetTravelFare();
        List<double> CalculateTravelCost(List<Vehicle> listVehicle, List<double> rates);
    }
}
