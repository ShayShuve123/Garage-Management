using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private List<Customer> s_Customers = new List<Customer>();

        //Garage methods//

        //7
        // פונקציה להדפסת פרטי לקוח ורכב מלאים לפי מספר רישוי
        public bool ShowFullVehicleDetails(string i_LicenseNumber) //i_LicenseNumber הוא בעצם המזהה הייחודי שאיתו אנחנו מוצאים את אובייטק הלקוח שבתוכו יש את הרכב
        {
            bool vehicleFound = false; // משתנה ביניים
            Customer customer = FindCustomerByLicenseNumber(i_LicenseNumber);

            if (customer != null)
            {
                Console.WriteLine(customer.ToString());
                vehicleFound = true;

            }
            else
            {
                vehicleFound = false;
            }

            return vehicleFound; // החזרת התוצאה בסוף הפונקציה

        }
        //6
        public bool chargeBattery(string i_LicenseNumber ,float i_HoursToCharge)
        {
            bool vehicleFound = false; // משתנה ביניים
            Customer customer = FindCustomerByLicenseNumber(i_LicenseNumber);

            if (customer == null)
            {
                vehicleFound = false;
            }
            else if (customer.VehicleCustomer.Engine is ElectricEngine electricEngine)
            {
                electricEngine.FillEnergySource(i_HoursToCharge); // זריקה במידה ויש חריגה
            }
            else
            {
                throw new ArgumentException("The vehicle does not have an electric engine and cannot be charged.");
            }

            return vehicleFound;
        }



        //auxiliary methods
        // פונקציה למציאת לקוח לפי מספר רישוי
        public Customer FindCustomerByLicenseNumber(string i_LicenseNumber)
        {
            Customer foundCustomer = null;

            foreach (Customer customer in s_Customers)
            {
                if (customer.VehicleCustomer.LicenseNumber == i_LicenseNumber)
                {
                    foundCustomer = customer;
                    break; // יוצאים מהלולאה כאשר מוצאים לקוח
                }
            }
            return foundCustomer;

        }

    }
}

//AddVehicle: Add a new customer and their vehicle to the garage.
//ChangeVehicleStatus: Change the status of a vehicle (e.g., in repair, repaired, paid).
//InflateAllTires: Inflate all vehicle tires to their max pressure.
//FuelVehicle: Refuel a vehicle if it’s a fuel engine.
//ChargeVehicle: Charge a vehicle if it’s electric.
//DisplayVehicleDetails: Display all details about a specific vehicle.