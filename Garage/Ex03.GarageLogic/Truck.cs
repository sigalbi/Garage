using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        bool m_isCarryingHazardousMaterials;
        float m_maxCarryWeightAllowed;

        public Truck(int numberOfWheel, float i_maxAirPressure, string i_typeOfengine, float i_maxOfQuantity, string i_typeOfGasolin = "NONE") : base(numberOfWheel, i_maxAirPressure, i_typeOfengine, i_maxOfQuantity, i_typeOfGasolin) { }

        public override List<string> QuestionsForAllVehicles() // this function hold the list of quastion that related to the Truck
        {
            List<string> QuestionsForTruck = new List<string>();
            QuestionsForTruck.Add("Please enter whether the truck carries hazardous materials <Y/N> and press 'Enter' ");
            QuestionsForTruck.Add("Please enter max permissible carrying weight and press 'Enter' ");
            return QuestionsForTruck;
        }

        public override void CheckInputAndUpdateForAllVehicles(string i_input, int i_numberOfQuestion) // this function check the input from user according to the question number
        {
            switch (i_numberOfQuestion)
            {
                case 1: // question number 1
                    {
                        CheckIsCarryingHazardousMaterialsAndUpdate(i_input); // call to function that check if the truck carries hazardous materials input and updeate the data members
                        break;
                    }
                case 2: // question number 2
                    {
                        CheckmaxCarryWeightAndUpdate(i_input); // call to function that check the max permissible carrying weight input and updeate the data members
                        break;
                    }
            }
        }

        public void CheckIsCarryingHazardousMaterialsAndUpdate(string i_input) // this function check if the truck carries hazardous materials input and updeate the data members
        {
           if(i_input.CompareTo("Y") == 0)
           {
                m_isCarryingHazardousMaterials = true; // updeate the data member
           }
            else if(i_input.CompareTo("N") == 0)
            {
                m_isCarryingHazardousMaterials = false; // updeate the data member
            }
           else // if the user input incurrect
            {
                throw new ArgumentException("you have to choose on of the following : <Y,N>");
            }
        }

        public void CheckmaxCarryWeightAndUpdate(string i_input) // this function check the max permissible carrying weight input and updeate the data members
        {
            bool correctInput; // a boolean variable that checks whether the input from the user is correct
            float maxCarryWeight;

            correctInput = float.TryParse(i_input, out maxCarryWeight); // try to parss to float
            if (!correctInput) // if the input from the user isnt correct
            {
                throw new FormatException("the input supposed to be only numbers");
            }
            m_maxCarryWeightAllowed = maxCarryWeight;
        }

        public override void GetDetailesOwnerVehicle(List<string> io_listOfDetailes)  // this function add the truck detailes to the list
        {
            GetDetailesVehicle(io_listOfDetailes);
            io_listOfDetailes.Add(string.Format("Is Carrying Hazardous Materials:{0}", m_isCarryingHazardousMaterials.ToString()));
            io_listOfDetailes.Add(string.Format("Max Carry Weight Allowed:{0}", m_maxCarryWeightAllowed.ToString()));
        }
    }
}
