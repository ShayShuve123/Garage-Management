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
using System.Text.RegularExpressions;

namespace Ex03.ConsoleUI
{
    public class UI
    {
        private GarageMenu m_GarageMenu;
        private Garage m_Garage;
        private GarageDisplay m_GarageDisplay;
        Enums.eVehicleType VehicleTypeT;

        public UI()
        {
            m_GarageMenu = new GarageMenu();
            m_Garage = new Garage();
            m_GarageDisplay = new GarageDisplay(m_Garage);

        }

        public void StartGarageMenu()
        {
            string userInput;
            int selectedOption = 0;
            bool validInput = false;
            bool again = true;

            Console.WriteLine(" Welcome to our premium Garage service.");
            while (again)
            {
                do
                {
                    Console.WriteLine("\nPress any key to continue to the main menu.");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine(" Please choose how we can assist you with your vehicle's needs :)");

                    m_GarageMenu.DisplayMenu(); 
                    userInput = getInput("selectedoptionfrommenu");
                    validInput = true;
                    selectedOption = int.Parse(userInput);

                    if (selectedOption == 8)
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

        private void userChoice(int i_UserSelectedOption)
        {
            try
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
                        InflateAllTiresToMax();
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
            catch (FormatException e)
            {
                Console.WriteLine($"\nInvalid input. Details: {e.Message}\n");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"\nError occurred. Details: {ex.Message}\n");
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine($"{ex.Message}  Valid Range: {ex.MinValue}-{ex.MaxValue}\n");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nError occurred. Details: {e.Message}\n");
            }
        }

        private void addNewVehicleToGarage()
        {
            Console.Clear();
            Console.Write("Please enter the license number: ");
            string licenseNum = getInput("numbers");

            if (!m_Garage.IsLicenseNumExist(licenseNum))
            {
                addNewVehicleToGarage(licenseNum);
            }
            else
            {
                Console.WriteLine("Vehicle is already in the garage. Changing its status to 'in repair'");
                m_Garage.ChangeVehicleStatus(licenseNum, eVehicleStatus.InRepair);
            }
        }
  
        private void addNewVehicleToGarage(string i_LicenseNumber)
        {
            CustomerVehicle customer;
            customer = createNewCustomer();
            Console.WriteLine("Please enter vehicle type:\n1-Fueled motorcycle  2-Elecric motorcycle  3-Fueled car  4-Electric car  5-Truck");
            string vehicleType = getInput("vehicleType");
            Enums.eVehicleType VehicleType = (Enums.eVehicleType)int.Parse(vehicleType);
            VehicleTypeT = VehicleType;
            Enums.eLicenseType LicenseType = Enums.eLicenseType.A1;

            if (VehicleType == eVehicleType.FuelMotorcycle || VehicleType == eVehicleType.ElecricMotorcycle)
            {
                Console.WriteLine("Please enter license type:\n1-A1  2-A2  3-AB  4-B1");
                string licenseType = getInput("choiceBetweenOnToFour");
                LicenseType = (Enums.eLicenseType)int.Parse(licenseType);
            }

            Console.Write("Please enter model name:");
            string ModelName = getInput("letter");

            if (VehicleTypeT == Enums.eVehicleType.FuelCar || VehicleTypeT == Enums.eVehicleType.FuelMotorcycle || VehicleTypeT == Enums.eVehicleType.Truck)
            {
                Console.WriteLine("Please enter the remaining energy in liters:");
            }
            else if (VehicleTypeT == Enums.eVehicleType.ElectricCar || VehicleTypeT == Enums.eVehicleType.ElecricMotorcycle)
            {
                Console.Write("Please enter the remaining energy in battery hours:");
            }

            string leftEnergy = getInput("remainingenergy");
            float LeftEnergy = float.Parse(leftEnergy);
            Console.Write("Please enter wheels' manufactutrer name:");
            string WheelsManufactorerName = getInput("letterAndNumbers");
            Console.Write("Please enter current air pressures in the wheels:");
            string airInWheels = getInput("airpressure");
            float AirInWheels = float.Parse(airInWheels);
            Enums.eNumberOfDoors NumDoors = Enums.eNumberOfDoors.Five;
            Enums.eVehicleColor Color = Enums.eVehicleColor.White;

            if (VehicleType == eVehicleType.FuelCar || VehicleType == eVehicleType.ElectricCar)
            {
                Console.WriteLine("Please enter car color type:\n1-Blue  2-White  3-Black  4-Red");
                string color = getInput("choiceBetweenOnToFour");
                Color = (Enums.eVehicleColor)int.Parse(color);
                Console.WriteLine("Please enter number of doors:\n1-Two Doors  2-Three Doors  3-Four Doors  4-Five Doors");
                string numDoors = getInput("choiceBetweenOnToFour");
                NumDoors = (Enums.eNumberOfDoors)int.Parse(numDoors);
            }

            float TruckCargoVolume = 0f;
            bool IsTransportingDangerousLoads = false;

            if (VehicleType == eVehicleType.Truck)
            {
                Console.WriteLine("What is your truck cargo volume? (a float number)");
                string truckCargoVolumeInput = getInput("float");
                TruckCargoVolume = float.Parse(truckCargoVolumeInput);

                Console.WriteLine("Does your truck transport dangerous materials?\n 1-YES  2-NO");
                string IsTransportingDangerousMaterialsAsString = getInput("yesno");

            }

            m_Garage.AddVehicle(customer.CustomerName, customer.CustomerPhoneNumber,
                            i_LicenseNumber,
                            LicenseType,
                            VehicleType,
                            ModelName,
                            LeftEnergy,
                            WheelsManufactorerName,
                            AirInWheels,
                            Color, NumDoors,
                            TruckCargoVolume,
                            IsTransportingDangerousLoads);

            Console.WriteLine($"\nVehicle with license {i_LicenseNumber} successfully added to the garage.\n");
        }

        private CustomerVehicle createNewCustomer()
        {
            string vehicleClientName, vehicleClientPhoneNumber;

            Console.Write("Please enter your name: ");
            vehicleClientName = getInput("letter");
            Console.Write("Please enter your phone (10 digits): ");
            vehicleClientPhoneNumber = getInput("phone");

            return new CustomerVehicle(vehicleClientName, vehicleClientPhoneNumber);
        }

        public string getInput(string i_InputType)
        {
            string userInput;
            bool isUserInputValid = false;

            do
            {
                userInput = Console.ReadLine();
                isUserInputValid = isValidInput(userInput, i_InputType);

                if (!isUserInputValid)
                {
                    Console.WriteLine("Invalid input! Please enter again.");
                }

            } while (!isUserInputValid);

            return userInput.Trim();
        }

        public bool isValidInput(string i_InputUser, string i_InputType)
        {
            bool isValid = true;
            Regex regex;
            float inputUserConvertedToFloat;

            try
            {
                if (string.IsNullOrEmpty(i_InputUser))
                {
                    throw new ArgumentException("Input cannot be empty.");
                }

                switch (i_InputType.ToLower())
                {
                    case "letter":
                        regex = new Regex(@"^[a-zA-Z]+$");
                        if (!regex.IsMatch(i_InputUser))
                        {
                            throw new FormatException("Must contain only English letters.");
                        }
                        break;

                    case "letterandnumbers":
                        regex = new Regex(@"^[a-zA-Z0-9]+$");
                        if (!regex.IsMatch(i_InputUser))
                        {
                            throw new FormatException("Must contain only English letters and digits.");
                        }
                        break;

                    case "phone":
                        regex = new Regex(@"^\d{10}$");
                        if (!regex.IsMatch(i_InputUser))
                        {
                            throw new FormatException("Phone number must contain exactly 10 digits.");
                        }
                        break;

                    case "vehicletype":
                        regex = new Regex(@"^[1-5]$");
                        if (!regex.IsMatch(i_InputUser))
                        {
                            throw new FormatException("Invalid vehicle type. Please enter a number between 1 and 5.");
                        }
                        break;
                    case "choicebetweenontofour":
                        regex = new Regex(@"^[1-4]$");
                        if (!regex.IsMatch(i_InputUser))
                        {
                            throw new FormatException("Invalid type. Please enter a number between 1 and 4.");
                        }
                        break;

                    case "islicenseingarage":

                        regex = new Regex(@"^\d+$");
                        if (!regex.IsMatch(i_InputUser))
                        {
                            throw new FormatException("Must include only digits (integer)");
                        }
                        if (!m_Garage.IsLicenseNumExist(i_InputUser))
                        {
                            throw new ArgumentException("License number doesn't exist in garage");
                        }
                        break;

                    case "float":
                        if (!float.TryParse(i_InputUser, out inputUserConvertedToFloat))
                        {
                            throw new FormatException("Invalid input. Please enter a valid float number.");
                        }
                        break;

                    case "numbers":
                        regex = new Regex(@"^\d+$");
                        if (!regex.IsMatch(i_InputUser))
                        {
                            throw new FormatException("Must include only digits (integer)");
                        }
                        break;

                    case "yesno":
                        regex = new Regex(@"^[1-2]$");
                        if (!regex.IsMatch(i_InputUser))
                        {
                            throw new FormatException("Invalid choice. Please enter 1 (Yes) or 2 (No).");
                        }
                        break;

                    case "enumstatus":
                        regex = new Regex(@"^[1-3]$");
                        if (!regex.IsMatch(i_InputUser))
                        {
                            throw new FormatException("Invalid status. Please enter a number between 1 (InRepair), 2 (Repaired), or 3 (Paid).");
                        }
                        break;

                    case "selectedoptionfrommenu":
                        regex = new Regex(@"^[1-8]$");
                        if (!regex.IsMatch(i_InputUser))
                        {
                            throw new FormatException("Please enter a number between 1 and 8, (8-Exit).");
                        }
                        break;

                    case "remainingenergy":
                        if (!float.TryParse(i_InputUser, out inputUserConvertedToFloat))
                        {
                            throw new FormatException("Invalid energy input. Must be a valid float.");
                        }
                        else
                        { 
                            switch (VehicleTypeT)
                            {
                                case Enums.eVehicleType.FuelMotorcycle:
                                    if (inputUserConvertedToFloat < 0 || inputUserConvertedToFloat > 6)
                                    {
                                        throw new ValueOutOfRangeException(0, 6f, "Fuel for regular motorcycle must be between 0 and 6 liters.");
                                    }
                                    break;

                                case Enums.eVehicleType.ElecricMotorcycle:
                                    if (inputUserConvertedToFloat < 0 || inputUserConvertedToFloat > 2.7f)
                                    {
                                        throw new ValueOutOfRangeException(0, 2.7f, "Battery capacity for electric motorcycle must be between 0 and 2.7 hours.");
                                    }
                                    break;

                                case Enums.eVehicleType.FuelCar:
                                    if (inputUserConvertedToFloat < 0 || inputUserConvertedToFloat > 49)
                                    {
                                        throw new ValueOutOfRangeException(0, 49, "Fuel for regular car must be between 0 and 49 liters.");
                                    }
                                    break;

                                case Enums.eVehicleType.ElectricCar:
                                    if (inputUserConvertedToFloat < 0 || inputUserConvertedToFloat > 5)
                                    {
                                        throw new ValueOutOfRangeException(0, 5, "Battery capacity for electric car must be between 0 and 5 hours.");
                                    }
                                    break;

                                case Enums.eVehicleType.Truck:
                                    if (inputUserConvertedToFloat < 0 || inputUserConvertedToFloat > 130)
                                    {
                                        throw new ValueOutOfRangeException(0, 130, "Fuel for truck must be between 0 and 130 liters.");
                                    }
                                    break;

                                default:
                                    throw new ArgumentException("Invalid vehicle type.");
                            }
                        }

                        break;

                    case "airpressure":
                        if (!float.TryParse(i_InputUser, out inputUserConvertedToFloat))
                        {
                            throw new FormatException("Invalid air pressure input. Must be a valid float.");
                        }
                        else
                        {
                            switch (VehicleTypeT)
                            {
                                case Enums.eVehicleType.FuelMotorcycle:
                                    if (inputUserConvertedToFloat < 0 || inputUserConvertedToFloat > 31)
                                    {
                                        throw new ValueOutOfRangeException(0, 31, "Air pressure for a regular motorcycle must be between 0 and 31.");
                                    }
                                    break;

                                case Enums.eVehicleType.ElecricMotorcycle:
                                    if (inputUserConvertedToFloat < 0 || inputUserConvertedToFloat > 31)
                                    {
                                        throw new ValueOutOfRangeException(0, 31, "Air pressure for an electric motorcycle must be between 0 and 31.");
                                    }
                                    break;

                                case Enums.eVehicleType.FuelCar:
                                    if (inputUserConvertedToFloat < 0 || inputUserConvertedToFloat > 33)
                                    {
                                        throw new ValueOutOfRangeException(0, 33, "Air pressure for a regular car must be between 0 and 33.");
                                    }
                                    break;

                                case Enums.eVehicleType.ElectricCar:
                                    if (inputUserConvertedToFloat < 0 || inputUserConvertedToFloat > 33)
                                    {
                                        throw new ValueOutOfRangeException(0, 33, "Air pressure for an electric car must be between 0 and 33.");
                                    }
                                    break;

                                case Enums.eVehicleType.Truck:
                                    if (inputUserConvertedToFloat < 0 || inputUserConvertedToFloat > 28)
                                    {
                                        throw new ValueOutOfRangeException(0, 28, "Air pressure for a truck must be between 0 and 28.");
                                    }
                                    break;

                                default:
                                    throw new ArgumentException("Invalid vehicle type.");
                            }
                        }
                        break;

                    default:
                        throw new ArgumentException("Invalid input type specified.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                isValid = false;
            }

            return isValid;
        }

        private Enums.eVehicleStatus getVehicleStatusFromUser()
        {
            Enums.eVehicleStatus eVehicleStatus;

            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter the new vehicle status you want to set for your car:\n1 - In Repair  2 - Repaired  3 - Paid");
                    string vehicleStatus = getInput("enumstatus");
                    eVehicleStatus = (Enums.eVehicleStatus)int.Parse(vehicleStatus);
                    Console.WriteLine("Status successfully changed.");
                    return eVehicleStatus;
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"\nInvalid input. Details: {e.Message}\n");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"\nError occurred. Details: {e.Message}\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\nError occurred. Details: {e.Message}\n");
                }
            }

        }

        private void showAllLicensePlates()
        {
            m_GarageDisplay.ShowAllLicensePlates(); 
        }

        private void updateVehicleStatus()
        {
            Console.WriteLine("Please enter the license number:");
            string licenseNumber = getInput("islicenseingarage");
            Enums.eVehicleStatus eVehicleStatus = getVehicleStatusFromUser();
            m_Garage.ChangeVehicleStatus(licenseNumber, eVehicleStatus);
        }

        public void InflateAllTiresToMax()
        {
            Console.Clear();
            Console.WriteLine("Please enter the license number:");
            string licenseNumber = getInput("IsLicenseInGarage");
            CustomerVehicle customerVehicle = m_Garage.CustomerVehicles[licenseNumber];

            foreach (Wheel wheel in customerVehicle.Vehicle.Wheels)
            {
                Console.WriteLine($"Current air pressure: {wheel.CurrentAirPressure}");
                Console.WriteLine($"Max air pressure: {wheel.MaxAirPressureByManufacturer}");
            }

            m_Garage.InflateAllTiresToMax(licenseNumber);
            Console.WriteLine("All tires have been successfully inflated to their maximum pressure.");
        }

        public void RefuelVehicle()
        {
            Console.Write("Please enter the license number:");
            string licenseNumber = getInput("IsLicenseInGarage");

            Console.WriteLine("Please enter fuel type:\n1-Soler  2-Octan95   3-Octan96   4-Octan98");
            string fuelType = getInput("choiceBetweenOnToFour");
            Enums.eFuelType FuelType = (Enums.eFuelType)int.Parse(fuelType);

            Console.Write("Please enter how much fuel liters to add:");
            float fuelToAdd = float.Parse(Console.ReadLine());
            m_Garage.RefuelVehicle(licenseNumber, fuelToAdd, FuelType);
            Console.WriteLine("Vehicle refueled successfully.");
        }

        private void showVehicleDetails()
        {
            Console.Write("Please enter the license number: ");
            string licenseNumber = getInput("IsLicenseInGarage");
            m_GarageDisplay.ShowVehicleDetails(licenseNumber);
        }

        private void showFullVehicleDetails(string i_LicenseNumber)
        {
            m_GarageDisplay.ShowFullVehicleDetails(i_LicenseNumber); 

        }

        private void rechargeBattery()
        {
            Console.Clear();
            Console.Write("Please enter the license number:");
            string licenseNumber = getInput("IsLicenseInGarage");

            Console.Write("Please enter the number of hours to charge:");
            string hoursToChargeStr = Console.ReadLine();

            if (float.TryParse(hoursToChargeStr, out float hoursToCharge))
            {
                m_Garage.ChargeBattery(licenseNumber, hoursToCharge);
                Console.WriteLine("The vehicle has been successfully charged.\n");
            }
            else
            {
                Console.WriteLine("Invalid input for hours to charge.\n");
            }

        }
    }
}















