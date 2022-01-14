using BLL;
using System;
using System.Collections.Generic;

namespace Tap_test
{
    public static class Menu
    {
        private static Person person = new Person();
        private static Vehicle vehicle = new Vehicle();
        private static List<double> travelFareRate = new List<double>();
        private static List<double> driverCost;

        public static void MainMenu()
        {
            Console.WriteLine("Please choose an option.");
            Console.WriteLine("1. Show Drivers.");
            Console.WriteLine("2. Get Travel Fare Rates.");
            Console.WriteLine("3. Exit program.");
            string numberOption = Console.ReadLine();

            switch (numberOption)
            {
                case "1":
                    ClearConsole();
                    ShowDrivers();
                    break;

                case "2":
                    GetRates();
                    break;

                case "3":
                    Environment.Exit(0);
                    break;

                default:
                    ClearConsole();
                    MainMenu();
                    break;
            }
        }

        public static void ShowDrivers(List<double> driverCost = null)
        {
            List<Person> listPerson = person.GetPeople();
            List<Vehicle> listVehicle = vehicle.GetVehicle();
            if (listPerson == null || listVehicle == null) AddDriver();
            Console.WriteLine("Name:    Surname:    Email:    VehicleType:    BaseFarePrice:    BaseFareDistance:    DriverCost:");
            int i = 0;
            foreach (var person in listPerson)
            {
                if (driverCost == null)
                {
                    Console.WriteLine("{0}:    {1}    |    {2}    |    {3}    |    {4}    |    {5}    |    {6}", i, person.Name, person.Surname, person.Email,
                                                                                            listVehicle[i].VehicleType, listVehicle[i].BaseFarePrice, listVehicle[i].BaseFareDistance);
                }
                else
                {
                    Console.WriteLine("{0}:    {1}    |    {2}    |    {3}    |    {4}    |    {5}    |    {6}    |    {7}", i, listPerson[i].Name, listPerson[i].Surname, listPerson[i].Email,
                                                                                                listVehicle[i].VehicleType, listVehicle[i].BaseFarePrice, listVehicle[i].BaseFareDistance, driverCost[i]);
                }
                i++;
            }

            Console.WriteLine();
            Console.WriteLine("1. Add Driver.");
            Console.WriteLine("2. Calculate Driver Rates.");
            Console.WriteLine("3. Update Driver.");
            Console.WriteLine("4. Delete Driver.");
            Console.WriteLine("5. Back.");
            string numberOption = Console.ReadLine();

            switch (numberOption)
            {
                case "1": 
                    AddDriver();
                    break;

                case "2":
                    CalculateRates();
                    break;

                case "3":
                    UpdateDriver();
                    break;

                case "4":
                    DeleteDriver();
                    break;

                case "5":
                    ClearConsole();
                    MainMenu();
                    break;

                default:
                    ClearConsole();
                    ShowDrivers();
                    break;
            }
        }

        public static void AddDriver()
        {
            Console.WriteLine("Please add Name.");
            person.Name = Console.ReadLine();
            Console.WriteLine("Please add Surname.");
            person.Surname = Console.ReadLine();
            Console.WriteLine("Please add Email.");
            person.Email = Console.ReadLine();
            Console.WriteLine("Please add Vehicle Type.");
            vehicle.VehicleType = Console.ReadLine();
            Console.WriteLine("Please add Base Fare Price.");
            vehicle.BaseFarePrice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please add Base Fare Distance.");
            vehicle.BaseFareDistance = Convert.ToDouble(Console.ReadLine());

            person.AddPerson();
            vehicle.AddVehicle();
            ClearConsole();
            Console.WriteLine("Driver added.");
            ShowDrivers();
        }

        public static void UpdateDriver()
        {
            List<Person> listPerson = person.GetPeople();
            List<Vehicle> listVehicle = vehicle.GetVehicle();
            int selectedUser;
            Console.WriteLine("Please select the number of the Driver you want to update.");
            selectedUser = Convert.ToInt32(Console.ReadLine());
            person.UpdatePerson(selectedUser, listPerson);
            vehicle.UpdateVehicle(selectedUser, listVehicle);
            ClearConsole();
            Console.WriteLine("Driver changed.");
            ShowDrivers();
        }

        public static void DeleteDriver()
        {
            List<Person> listPerson = person.GetPeople();
            List<Vehicle> listVehicle = vehicle.GetVehicle();
            int selectedUser;
            Console.WriteLine("Please select the number of the Driver you want to delete.");
            selectedUser = Convert.ToInt32(Console.ReadLine());
            person.DeletePerson(selectedUser, listPerson);
            vehicle.DeleteVehicle(selectedUser, listVehicle);
            ClearConsole();
            Console.WriteLine("Driver deleted.");
            ShowDrivers();
        }

        public static void CalculateRates()
        {
            if (travelFareRate.Count == 0)
            {
                ClearConsole();
                Console.WriteLine("Please Update Rates In Main Menu.");
                Console.WriteLine();
                ShowDrivers();
                return;
            }
            ClearConsole();
            List<Vehicle> listVehicle = vehicle.GetVehicle();
            List<double> driverCost = vehicle.CalculateTravelCost(listVehicle, travelFareRate);
            ShowDrivers(driverCost);
        }

        public static void GetRates()
        {
            ClearConsole();
            travelFareRate = vehicle.GetTravelFare();
            Console.WriteLine("Travel Fare Rates Updated.");
            MainMenu();
        }

        public static void ClearConsole()
        {
            Console.Clear();
        }
    }
}