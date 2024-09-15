using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ex03.ConsoleUI
{
    public class UI
    {
        //לא לשכוח למקום פה את הקצים של האקספשנים כי רק מפה מותר להדפיסססססססססססססססססססססססססססססססססססססססססססססססס
        private static Garage s_Garage = new Garage();
        private static string[] m_GarageMenu = new string[]
                {
            "1) Add a new vehicle to the garage",
            "2) Show all vehicle license plates",
            "3) Update vehicle status",
            "4) Inflate all tires",
            "5) Fill the Vehicle's Energy Source", //FillEnergySource
            "6) Charge vehicle",
            "7) Show detailed information for a vehicle",
            "8) Exit "
        };
        public static void StartGarageMenu()
        {
            string userInput;
            int selectedOption = 0; // משתנה אחסון עבור הבחירה
            bool validInput = false;

            Console.WriteLine(" Welcome to our premium Garage service.Please choose how we can assist you with your vehicle's needs (1-8):");

            do
            {
                displayGarageMenu();
                userInput = Console.ReadLine();
                validInput = validateInput(userInput, out selectedOption);
                if (validInput && selectedOption == 8)
                {
                    Console.Clear();
                    Console.WriteLine("Thanks for visiting at our Garage! We will be happy to see you again");
                    Thread.Sleep(2000);
                }
                
            }
            while (validInput != true); /// User selected fals
            userChoice(selectedOption);

        }
        private static bool validateInput(string userInput, out int selectedOption)
        {
            bool valid = false;

            if (int.TryParse(userInput, out selectedOption) && selectedOption >= 1 && selectedOption <= 8)
            {
                valid = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 8, (8-Exit).");
            }

            return valid;
        }
        private static void displayGarageMenu()
        {
            foreach (string option in m_GarageMenu)
            {
                Console.WriteLine(option);
            }
        }

        private static void userChoice(int i_UserSelectedOption)
        {
            switch (i_UserSelectedOption)
            {
                //לשנות את כל שמות הפנקצית-------------------------------------------------------------------------------------------------
                case 1:
                    ///*insertNewVehicle*/();
                    break;

                case 2:
                    //displayAllVehicles();
                    break;

                case 3:
                    //changeVehicleStatus();
                    break;

                case 4:
                    //inflateAirPressureToMax();
                    break;

                case 5:
                    //fuelTankVehicle();
                    break;

                case 6:
                    chargeVehicleBattery(); 
                    break;

                case 7:
                   
                   showVehicleDetails();
                    break;
            }
        }

        //7
        private static void showVehicleDetails()
        {
            Console.WriteLine("Please enter the license number:");
            string licenseNumber = Console.ReadLine();
            bool ifLicenseNumberExists = s_Garage.ShowFullVehicleDetails(licenseNumber);

            if (!ifLicenseNumberExists)
            {
                HandleLicenseNumberNotFound(licenseNumber);
            }
        }
        public static void HandleLicenseNumberNotFound(string i_LicenseNumber) //אם רשיון אין לנו במוסך אז נחזיר את זה --אם לא מצאנו את הלקוח עם הרשיון רכב הזה
        {
            Console.WriteLine($"No vehicle with license number {i_LicenseNumber} found in the garage.");
            Thread.Sleep(2000);
            Console.Clear(); // ניקוי המסך לפני החזרה לתפריט הראשי
            UI.StartGarageMenu(); // חזרה לתפריט הראשי
        }

        private static void chargeVehicleBattery()
        {
            Console.WriteLine("Please enter the vehicle's license number for charging:");
            string licenseNumber = Console.ReadLine();

            Console.WriteLine("Please enter the number of hours to charge:");
            string hoursinput = Console.ReadLine();
            
            if (float.TryParse(hoursinput, out float hoursToCharge))
            {
                bool ifLicenseNumberExists = s_Garage.chargeBattery(licenseNumber, hoursToCharge);
                   
                    if (ifLicenseNumberExists == false)
                    {
                        HandleLicenseNumberNotFound(licenseNumber);
                    }
                    else 
                    {
                       Console.WriteLine("The vehicle has been successfully charged.");
                       Console.Clear(); // ניקוי המסך לפני החזרה לתפריט הראשי
                       Thread.Sleep(1500);
                       UI.StartGarageMenu(); // חזרה לתפריט הראשי

                    }
            }
            else
            {
                Console.WriteLine("Invalid input for hours to charge.");
            }

        }
















        //im am not shure is need to be her but all the  Console.WriteLine need to be in the UI so...?
        //public void RefuelVehicle(Vehicle vehicle, float fuelToAdd, object fuelType)
        //{
        //    try
        //    {
        //        vehicle.Engine.FillEnergySource(fuelToAdd, fuelType);
        //        Console.WriteLine("Vehicle refueled successfully.");
        //    }
        //    catch (ArgumentNullException ex)
        //    {
        //        Console.WriteLine(ex.Message);  // טיפול במקרה ש-`null` סופק כפרמטר
        //    }
        //    catch (ValueOutOfRangeException ex)
        //    {
        //        Console.WriteLine(ex.Message);  // טיפול במקרה של חריגה מקיבולת הטנק
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        Console.WriteLine(ex.Message);  // טיפול במקרה של סוג דלק לא חוקי
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("An unexpected error occurred: " + ex.Message);  // טיפול בחריגות כלליות
        //    }
        //}






    }
}
