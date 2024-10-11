using Ex03.GarageLogic;
using System;

public class GarageDisplay
{
    private Garage m_Garage;

    public GarageDisplay(Garage i_Garage)
    {
        m_Garage = i_Garage;
    }

    public void ShowFullVehicleDetails(string i_LicenseNumber)
    {
        CustomerVehicle customerVehicle = m_Garage.CustomerVehicles[i_LicenseNumber];
        Console.WriteLine("******************* Vehicle Details *******************\n");
        Console.WriteLine(customerVehicle.ToString());
    }

    public void ShowVehicleDetails(string licenseNumber)
    {
        Console.Clear();
        Console.Write("Please enter the license number:");
        string licenseNum = Console.ReadLine();
        ShowFullVehicleDetails(licenseNum);
    }

    public void ShowAllLicensePlates()
    {
        Console.WriteLine("Do you want to filter by vehicle status?");
        Console.WriteLine("1) Yes");
        Console.WriteLine("2) No");

        string filterChoice = Console.ReadLine();
        bool filterByStatus = filterChoice == "1";

        if (filterByStatus)
        {
            Console.WriteLine("Please select the status to filter by:");
            Console.WriteLine("1) In Repair");
            Console.WriteLine("2) Repaired");
            Console.WriteLine("3) Paid");
            string statusChoice = Console.ReadLine();
            Enums.eVehicleStatus chosenStatus = (Enums.eVehicleStatus)int.Parse(statusChoice);
            Console.Write($"\nVehicles with status {chosenStatus}:\n");

            foreach (var vehicle in m_Garage.CustomerVehicles)
            {
                if (vehicle.Value.VehicleStatus == chosenStatus)
                {
                    Console.WriteLine(vehicle.Key);
                }
            }
        }
        else
        {
            Console.WriteLine("\nAll vehicle license plates in the garage:\n");
            foreach (var vehicle in m_Garage.CustomerVehicles)
            {
                Console.WriteLine(vehicle.Key);
            }
        }
    }
}
