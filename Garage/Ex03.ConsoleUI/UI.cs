using Ex03.GarageLogic;
using Ex03.GarageLogic.Types_of_vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading;
using static Ex03.GarageLogic.Enums;

namespace Ex03.ConsoleUI
{
    public class UI
    {
        private Garage s_Garage = new Garage();
        private string[] m_GarageMenu = new string[]
              {
            "1) Add a new vehicle to the garage",
            "2) Show all vehicle license plates",
            "3) Update vehicle status",
            "4) Inflate all tires",
            "5) Refuel a vehicle",
            "6) Charge a vehicle",
            "7) Show detailed information for a vehicle",
            "8) Exit\n"
        };

        public void StartGarageMenu()
        {
            string userInput;
            int selectedOption = 0;
            bool validInput = false;

            Console.WriteLine(" Welcome to our premium Garage service.");
            Console.WriteLine(" Please choose how we can assist you with your vehicle's needs (1-8):\n");

            bool again = true;
            while (again)
            {
                do
                {
                    displayGarageMenu();
                    userInput = Console.ReadLine();
                    validInput = validateInput(userInput, out selectedOption);
                    if (validInput && selectedOption == 8)
                    {
                        Console.Clear();
                        Console.WriteLine("Thanks for visiting at our Garage! We will be happy to see you again");
                        Thread.Sleep(3000);
                        again = false; ;
                    }

                }
                while (validInput != true);
                userChoice(selectedOption);
            }

        }

        private bool validateInput(string userInput, out int selectedOption)
        {
            bool valid = false;

            if (int.TryParse(userInput, out selectedOption) && selectedOption >= 1 && selectedOption <= 8)
            {
                valid = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 8, (8-Exit).\n");
            }

            return valid;
        }

        private void displayGarageMenu()
        {
            foreach (string option in m_GarageMenu)
            {
                Console.WriteLine(option);
            }
        }

        private void userChoice(int i_UserSelectedOption)
        {
            switch (i_UserSelectedOption)
            {
                case 1:
                    addNewVehicleToGarage();

                    break;

                case 2:
                    showAllLicensePlates();
                    break;

                case 3:
                    updateVehicleStatus();
                    break;

                case 4:
                    inflateAllTiresToMax();
                    break;

                case 5:
                    RefuelVehicle();
                    break;

                case 6:
                    rechargeBattery();
                    break;

                case 7:

                    showVehicleDetails();
                    break;
            }
        }

        private void addNewVehicleToGarage()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter the license number");
                    string licenseNum = Console.ReadLine();
                    bool ifLicenseNumberExists = s_Garage.ShowFullVehicleDetails(licenseNum);

                    if (ifLicenseNumberExists)
                    {
                        Console.WriteLine("This veicle is already in the garage. Changing it status to IN REPAIR.\n");
                        s_Garage.ChangeVehicleStatus(licenseNum, Enums.eVehicleStatus.InRepair);
                        return;
                    }

                    Console.WriteLine("Please enter your name");
                    string CustomerName = Console.ReadLine();

                    Console.WriteLine("Please enter your phone");
                    string CustomerPhone = Console.ReadLine();

                    Console.WriteLine("Please enter vehicle type");
                    Console.WriteLine("1-motorcycle  2-elecric motorcycle  3-fueled car  4-electric car  5-truck");
                    int VehicleTypeAsInt = int.Parse(Console.ReadLine());
                    Enums.eVehicleType VehicleType = (Enums.eVehicleType)VehicleTypeAsInt;

                    Enums.eLicenseType LicenseType = Enums.eLicenseType.A1;
                    if (VehicleType == eVehicleType.FuelMotorcycle || VehicleType == eVehicleType.ElecricMotorcycle)
                    {
                        Console.WriteLine("Please enter license type(1-A1  2-A2  3-AB  4-B1):");
                        int LicenseTypeAsInt = int.Parse(Console.ReadLine());
                        LicenseType = (Enums.eLicenseType)LicenseTypeAsInt;
                    }

                    Console.WriteLine("Please enter model name");
                    string ModelName = Console.ReadLine();

                    Console.WriteLine("Please enter current energy (num of liters for fuel/num of hours for battery)");
                    float LeftEnergy = float.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter wheels' manufactutrer name");
                    string WheelsManufactorerName = Console.ReadLine();

                    Console.WriteLine("Please enter current air pressures in the wheels");
                    float AirInWheels = float.Parse(Console.ReadLine());

                    Enums.eNumberOfDoors NumDoors = Enums.eNumberOfDoors.Five;
                    Enums.eVehicleColor Color = Enums.eVehicleColor.White;
                    if (VehicleType == eVehicleType.FuelCar || VehicleType == eVehicleType.ElectricCar)
                    {
                        Console.WriteLine("Please enter car color (1-Blue  2-White  3-Black  4-Red)");
                        int ColorAsInt = int.Parse(Console.ReadLine());
                        Color = (Enums.eVehicleColor)ColorAsInt;

                        Console.WriteLine("Please enter number of doors (2, 3, 4, 5)");
                        int NumDoorsAsInt = int.Parse(Console.ReadLine());
                        NumDoors = (Enums.eNumberOfDoors)NumDoorsAsInt;
                    }

                    float TruckCargoVolume = 0f;
                    bool IsTransportingDangerousLoads = false;
                    if (VehicleType == eVehicleType.Truck)
                    {
                        Console.WriteLine("What is your truck cargo volume? (a float number)");
                        TruckCargoVolume = float.Parse(Console.ReadLine());

                        Console.WriteLine("Does your truck transport dangerous materials? (y/n)");
                        string IsTransportingDangerousMaterialsAsString = Console.ReadLine();
                        if (IsTransportingDangerousMaterialsAsString == "y")
                        {
                            IsTransportingDangerousLoads = true;
                        }
                        else if (IsTransportingDangerousMaterialsAsString == "n")
                        {
                            IsTransportingDangerousLoads = false;
                        }
                        else
                        {
                            throw new FormatException("Bad user input");
                        }
                    }

                    s_Garage.AddVehicle(CustomerName, CustomerPhone,
                                    licenseNum,
                                    LicenseType,
                                    VehicleType,
                                    ModelName,
                                    LeftEnergy,
                                    WheelsManufactorerName,
                                    AirInWheels,
                                    Color, NumDoors,
                                    TruckCargoVolume,
                                    IsTransportingDangerousLoads);

                    break;  // if we reached this break then no exception was thrown
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nInvalid input. Sorry, Lets try again.\n");
                }
                catch (Exception)
                {
                    Console.WriteLine("\nError occurred. Sorry, Lets try again.\n");
                }
            }
        }

        private Enums.eVehicleStatus getVehicleStatusFromUser()
        {
            Enums.eVehicleStatus eVehicleStatus;

            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter vehicle status (1 - InRepair 2 - Repaired 3 - Paid)");
                    int vehicleStatusAsInt = int.Parse(Console.ReadLine());
                    eVehicleStatus = (Enums.eVehicleStatus)vehicleStatusAsInt;
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nInvalid input. Sorry, Lets try again.\n");
                }
                catch (Exception)
                {
                    Console.WriteLine("\nError occurred. Sorry, Lets try again.\n");
                }
            }

            return eVehicleStatus;
        }

        private void showAllLicensePlates()
        {
            Enums.eVehicleStatus eVehicleStatus = getVehicleStatusFromUser();

            if (s_Garage.CustomerVehicles.Count == 0)
            {
                Console.WriteLine("No vehicles in the Garage\n");
                return;
            }

            int count = 0;
            foreach (var item in s_Garage.CustomerVehicles)
            {
                if (item.Value.VehicleStatus == eVehicleStatus)
                {
                    Console.WriteLine(item.Key);
                    count++;
                }
            }

            if (count == 0)
            {
                Console.WriteLine("No vehicles of selected status in the garage.\n");
            }
        }

        public void updateVehicleStatus()
        {
            Console.WriteLine("Please enter the license number:");
            string licenseNumber = Console.ReadLine();

            Enums.eVehicleStatus eVehicleStatus = getVehicleStatusFromUser();

            bool isVehicleFound = s_Garage.ChangeVehicleStatus(licenseNumber, eVehicleStatus);

            if (isVehicleFound)
            {
                Console.WriteLine("Done\n");
            }
            else
            {
                Console.WriteLine("Sorry, there is no such a car in the garage.");
            }
        }

        public void inflateAllTiresToMax()
        {
            Console.WriteLine("Please enter the license number:");
            string licenseNumber = Console.ReadLine();

            bool isVehicleFound = s_Garage.InflateAllTiresToMax(licenseNumber);

            if (isVehicleFound)
            {
                Console.WriteLine("Done\n");
            }
            else
            {
                Console.WriteLine("Sorry, there is no such a car in the garage.");
            }
        }

        public void RefuelVehicle()
        {
            try
            {
                Console.WriteLine("Please enter the license number:");
                string licenseNumber = Console.ReadLine();

                Console.WriteLine("Please enter fuel type (1-Soler, 2-Octan95 3-Octan96 4-Octan98");
                int FuelTypeAsInt = int.Parse(Console.ReadLine());
                Enums.eFuelType fuelType = (Enums.eFuelType)FuelTypeAsInt;

                Console.WriteLine("Please enter how much fuel liters to add:");
                float fuelToAdd = float.Parse(Console.ReadLine());
                s_Garage.refuelVehicle(licenseNumber, fuelToAdd, fuelType);
                Console.WriteLine("Vehicle refueled successfully.\n");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Input has an invalid format");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine($"{ex.Message}  Valid Range: {ex.MinValue}-{ex.MaxValue}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

        }

        private void showVehicleDetails()
        {
            Console.WriteLine("Please enter the license number:");
            string licenseNumber = Console.ReadLine();
            bool ifLicenseNumberExists = s_Garage.ShowFullVehicleDetails(licenseNumber);

            if (!ifLicenseNumberExists)
            {
                Console.WriteLine("Sorry, there is no such a car in the garage.");
                return;
            }
        }

        private void rechargeBattery()
        {
            try
            {
                Console.WriteLine("Please enter the license number:");
                string licenseNumber = Console.ReadLine();

                Console.WriteLine("Please enter the number of minutes to charge:");
                string minutesToChargeStr = Console.ReadLine();

                if (float.TryParse(minutesToChargeStr, out float minutesToCharge))
                {
                    bool ifLicenseNumberExists = s_Garage.chargeBattery(licenseNumber, minutesToCharge / 60f);

                    if (ifLicenseNumberExists == false)
                    {
                        Console.WriteLine("Sorry, there is no such a car in the garage.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("The vehicle has been successfully charged.\n");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input for hours to charge.\n");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Input has an invalid format");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine($"{ex.Message}  Valid Range: {ex.MinValue}-{ex.MaxValue}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

        }
    }
}
