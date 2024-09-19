using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UI garageUI = new UI(); // יצירת מופע של המחלקה UI
            garageUI.StartGarageMenu(); // קריאה לפונקציה דרך המופע
            
        }
    }
}
