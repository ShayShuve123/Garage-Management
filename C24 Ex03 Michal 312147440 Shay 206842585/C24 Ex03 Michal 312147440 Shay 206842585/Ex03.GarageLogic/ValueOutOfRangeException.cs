using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//לפנייייייייייי שמתחילים את הפרוייקט לבנות קלאס דיאגרם לא לוותר על השלב!!
//cpsolation -internal/public/protected/private
//validations 
namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public float MaxValue { get; }
        public float MinValue { get; }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, string i_Message)
            : base(i_Message)
        {
            MinValue = i_MinValue;
            MaxValue = i_MaxValue;
        }
    }

}
