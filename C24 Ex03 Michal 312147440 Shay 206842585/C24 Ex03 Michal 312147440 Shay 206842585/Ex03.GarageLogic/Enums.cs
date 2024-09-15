using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//לפנייייייייייי שמתחילים את הפרוייקט לבנות קלאס דיאגרם לא לוותר על השלב!!
//cpsolation -internal/public/protected/private
//validations 
namespace Ex03.GarageLogic
{
    public class Enums //ערבבתי תסדר
    {
        public enum eEngineType
        {
            Electric =1,
            Fuel,
        }

        public enum eNumberOfDoors
        {
            Two = 1,//why
            Three,
            Four,
            Five,
        }

        public enum eLicenseType
        {
            A1 = 1,//why?
            A2,
            AB,
            B1,
        }

        public enum eVehicleColor
        {
            Blue = 1,//why? probably :
            White, //2
            Black,//3
            Red,//4
        }

        public enum eVehicleStatus
        {
            InRepair = 1,//
            Repaired,
            Paid,
        }

        public enum eFuelType
        {
            Soler = 1,//why?
            Octan95,
            Octan96,
            Octan98,

        }
    }
}
