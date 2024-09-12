using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//לפנייייייייייי שמתחילים את הפרוייקט לבנות קלאס דיאגרם לא לוותר על השלב!!
//
namespace Ex03.GarageLogic//remmber to change this namespace when i arraneg the all projects
{
    public abstract class Vehicle //protected related only to inaritence
    {
        //data members//
        private string m_ModelName;
        private string m_LicenseNumber;//TO chack if in realty license number supposed to change?
        protected Wheel[] m_Wheels; //why not list ? askk
        private VehicleEngine m_Engine; 

        //constractor//
        public Vehicle(string i_LicenseNumber ,string i_ModelName, VehicleEngine i_Engine)
        {
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_ModelName = i_ModelName;
            this.m_Engine = i_Engine;
            //weels?

        }


        //get & set -proprtis //

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }

            set
            {
                this.m_ModelName = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }

            set
            {
                this.m_LicenseNumber = value;
            }
        }

        public Wheel[] Wheels
        {
            get
            {
                return this.m_Wheels;
            }

            set
            {
                this.m_Wheels = value;
            }
        }

        public VehicleEngine Engine
        {
            get
            {
                return this.m_Engine;
            }

            set
            {
                this.m_Engine = value;
            }
        }

        // להציג נתונים מלאים של רכב לפי מספר רישוי )מספר רישוי, שם דגם, שם בעלים, מצב 
       // במוסך, פירוט הגלגלים )לחץ אוויר ויצרן(, מצב דלק + סוג דלק / מצב מצבר, ושאר הפרטים
       // הרלוונטיים// לסוג הרכב הספציפי(
       //abstruct for chid to implemnt 
    }
}
