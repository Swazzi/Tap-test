using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class Vehicle : IVehicle
    {
        private string vehicleType;
        private double baseFarePrice;
        private double baseFareDistance;

        public Vehicle(string vehicleType, double baseFarePrice, double baseFareDistance)
        {
            this.vehicleType = vehicleType;
            this.baseFarePrice = baseFarePrice;
            this.baseFareDistance = baseFareDistance;
        }

        public Vehicle()
        {
        }

        public double BaseFareDistance
        {
            get { return baseFareDistance; }
            set { baseFareDistance = value; }
        }

        public double BaseFarePrice
        {
            get { return baseFarePrice; }
            set { baseFarePrice = value; }
        }

        public string VehicleType
        {
            get { return vehicleType; }
            set { vehicleType = value; }
        }

        public List<Vehicle> GetVehicle()
        {
            List<Vehicle> listVehicle = new List<Vehicle>();
            TextEditor text = new TextEditor();
            List<string> vehicle = text.ReadFile("Vehicle.txt");
            if (vehicle == null) return null;

            foreach (var item in vehicle)
            {
                string[] newVehicle = item.Split(",");
                this.VehicleType = newVehicle[0];
                this.BaseFarePrice = Convert.ToDouble(newVehicle[1]);
                this.BaseFareDistance = Convert.ToDouble(newVehicle[2]);

                listVehicle.Add(new Vehicle(this.VehicleType, this.BaseFarePrice, this.BaseFareDistance));
            }
            return listVehicle;
        }

        public void AddVehicle()
        {
            TextEditor text = new TextEditor();
            string line = string.Format("{0},{1},{2}", this.VehicleType, this.BaseFarePrice, this.BaseFareDistance);
            text.WriteLine("Vehicle.txt", line);
        }

        public Vehicle UpdateVehicle(int userID, List<Vehicle> listVehicle)
        {
            TextEditor text = new TextEditor();
            Console.Clear();
            Console.WriteLine("Please enter new VehicleType.");
            listVehicle[userID - 1].VehicleType = Console.ReadLine();
            Console.WriteLine("Please enter new BaseFarePrice.");
            listVehicle[userID - 1].BaseFarePrice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter new BaseFareDistance.");
            listVehicle[userID - 1].BaseFareDistance = Convert.ToDouble(Console.ReadLine());

            string[] arrayVehicle = new string[listVehicle.Count];
            int i = 0;

            foreach (var vehicle in listVehicle)
            {
                arrayVehicle[i] = string.Format("{0},{1},{2}", vehicle.vehicleType, vehicle.baseFarePrice, vehicle.baseFareDistance);
                i++;
            }
            text.WriteFile("Vehicle.txt", arrayVehicle, false);
            return this;
        }

        public Vehicle DeleteVehicle(int userID, List<Vehicle> listVehicle)
        {
            TextEditor text = new TextEditor();

            listVehicle.RemoveAt(userID - 1);

            string[] arrayVehicle = new string[listVehicle.Count];
            int i = 0;

            foreach (var vehicle in listVehicle)
            {
                arrayVehicle[i] = string.Format("{0},{1},{2}", vehicle.vehicleType, vehicle.baseFarePrice, vehicle.baseFareDistance);
                i++;
            }
            text.WriteFile("Vehicle.txt", arrayVehicle, false);
            return this;
        }

        public List<double> GetTravelFare()
        {
            TextEditor text = new TextEditor();
            List<string> vehicle = text.ReadFile("BaseFare.csv");
            List<double> travelFare = new List<double>();
            foreach (var item in vehicle)
            {
                string[] traveFareInfo = item.Split(",");
                travelFare.Add(Convert.ToDouble(traveFareInfo[0]));
                travelFare.Add(Convert.ToDouble(traveFareInfo[1]));
                travelFare.Add(Convert.ToDouble(traveFareInfo[2]));
            }

            return travelFare;
        }

        public List<double> CalculateTravelCost(List<Vehicle> listVehicle, List<double> rates)
        {
            List<double> newCost = new List<double>();
            double newValue;
            foreach (var item in listVehicle)
            {
                newValue = rates[0] - item.BaseFareDistance;
                if (newValue <= 0)
                {
                    newCost.Add((item.baseFarePrice + newValue));
                }
                else
                {
                    newValue = newValue / rates[1];
                    newValue = (newValue * rates[2]);
                    newCost.Add((item.baseFarePrice + newValue));
                }
            }

            return newCost;
        }
    }
}