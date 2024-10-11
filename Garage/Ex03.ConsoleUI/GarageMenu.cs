using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class GarageMenu
    {
        private string[] m_GarageMenu = new string[]
        {
        "Please enter one of the below options (1 - 8):",
        "1) Add a new vehicle to the garage",
        "2) Show all vehicle license plates",
        "3) Update vehicle status",
        "4) Inflate all tires",
        "5) Refuel a vehicle",
        "6) Charge a vehicle",
        "7) Show detailed information for a vehicle",
        "8) Exit"
        };

        public void DisplayMenu()
        {
            foreach (string option in m_GarageMenu)
            {
                Console.WriteLine(option);
            }
        }
    }

}
