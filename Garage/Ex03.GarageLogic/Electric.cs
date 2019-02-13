using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Electric : Engine
    {
        public Electric(float i_maxOfQuantity) :base (i_maxOfQuantity) { }
        public override void FuleVehicle(float i_quantityToAddInMinutes) // this function charge the vehicle
        {
            float maxBatteryTimeInHours = MaxEngineQuantity;
            float batteryTimeRemainingInHours = CurrentEngineQuantity;
            float batteryTimeToAdd = i_quantityToAddInMinutes / 60; // Conversion from minutes to hours

            if (batteryTimeRemainingInHours + batteryTimeToAdd > maxBatteryTimeInHours) // If add the time that user requested exceeds the maximum
            {
                throw new ValueOutOfRangeException(0, (maxBatteryTimeInHours - batteryTimeRemainingInHours));
            }
            else // we can add the time the user requested
            {
                CurrentEngineQuantity = batteryTimeRemainingInHours + batteryTimeToAdd;  // updeate the current engine quantity
            }
        }

        public override List<string> QuestionsForEngine() // this function hold the list of quastion that related to the electric engine
        {
            List<string> QuestionsForEngine = new List<string>();
            QuestionsForEngine.Add("Please enter the batterty time remaining in hours and press 'Enter' ");
            return QuestionsForEngine;
        }

        public override void CheckInputAndUpdateForEngine(string i_input, int i_numberOfQuestion) // this function check the input from user according to the question number
        {
            switch (i_numberOfQuestion)
            {
                case 1:   // question number 1
                    {
                        CheckBatteryTime(i_input); // call to function that check the batterty time input from user and updeate the data member
                        break;
                    }

            }
        }

        public void CheckMaxBattry(string i_input) // this function check the max batterty time input from user and updeate the data member
        {
            bool correctInput; // a Boolean variable that says whether the input from the user is correct
            float maxBattryTime;

            correctInput = float.TryParse(i_input, out maxBattryTime); // try to parss the input to float
            if (!correctInput) // if the parss did not succeed
            {
                    throw new FormatException("The input supposed to be only numbers");
            }
            MaxEngineQuantity = maxBattryTime ; 
        }

        public void CheckBatteryTime(string i_input) // this function check the batterty time input from user and updeate the data member
        {
            bool correctInput; // a Boolean variable that says whether the input from the user is correct
            float currentBattryTime;

            correctInput = float.TryParse(i_input, out currentBattryTime); // try to parss the input to float
            if (!correctInput) // if the parss did not succeed
            {
                throw new FormatException("The input supposed to be only numbers");
            }
            else if(currentBattryTime > MaxEngineQuantity) // if the input is too big
            {
                throw new ArgumentException("The current Engine Quantity have to be lass then the max Engine Quantity");
            }
            CurrentEngineQuantity = currentBattryTime;
        }

        public override void GetDetailesEngine(List<string> io_listOfDetailes)  // this function add the electric engine detailes to the list
        {
            io_listOfDetailes.Add(string.Format("Max battery :{0}", MaxEngineQuantity.ToString()));
            io_listOfDetailes.Add(string.Format("Current battery:{0}", CurrentEngineQuantity.ToString()));
        }
    }
}
