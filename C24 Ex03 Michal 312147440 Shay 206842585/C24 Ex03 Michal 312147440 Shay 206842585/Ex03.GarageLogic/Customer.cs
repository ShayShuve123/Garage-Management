using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class Customer
    {
        //data members//
        private string m_CustomerName; //readonly
        private string m_CustomerPhoneNumber;
        private eVehicleStatus m_CustomerStatus;
        private Vehicle m_VehicleCustomer;

        public Customer(string i_CustomerName, string i_CustomerPhoneNumber) 
        {
            this.m_CustomerName = i_CustomerName;
            this.m_CustomerPhoneNumber = i_CustomerPhoneNumber;
            this.m_CustomerStatus = eVehicleStatus.InRepair; // default status when a customer registers the vehicle

        }

        //get & set -proprtis //

        public string CustomerName
        {
            get
            {
                return m_CustomerName;
            }
            set
            {
                m_CustomerName = value;
            }
        }

        public string CustomerPhoneNumber
        {
            get
            {
                return m_CustomerPhoneNumber;
            }
            set
            {
                m_CustomerPhoneNumber = value;
            }
        }

        public eVehicleStatus CustomerStatus
        {
            get
            { 
                return m_CustomerStatus;
            }
            set 
            { 
                m_CustomerStatus = value; 
            }
        }

        public Vehicle VehicleCustomer
        {
            get 
            { 
                return m_VehicleCustomer;
            }
            set
            {
                m_VehicleCustomer = value;
            }
        }
        //את זה נדפיס בUI שנרצה לממש את סעיף 7 בתרגיל זה בול 7 יש פה את כל ההדפסות
        public override string ToString()
        {
            StringBuilder customerDetails = new StringBuilder();
            customerDetails.AppendLine($"Customer Name: {m_CustomerName}");
            customerDetails.AppendLine($"Phone Number: {m_CustomerPhoneNumber}");
            customerDetails.AppendLine($"Vehicle Status: {m_CustomerStatus}");
            customerDetails.AppendLine(m_VehicleCustomer.ToString()); 

            return customerDetails.ToString();
        }

    }
}
