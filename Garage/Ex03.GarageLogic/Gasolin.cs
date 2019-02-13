using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Gasolin : Engine
    {
        public enum eFuelType { SOLER, OCTAN95, OCTAN96, OCTAN98 }; // Types of fuel
        private eFuelType m_fuelType;

        public Gasolin(float i_maxOfQuantity, string i_typeOfGasolin) : base(i_maxOfQuantity)
        {
            m_fuelType = (eFuelType)Enum.Parse(typeof(eFuelType), i_maxOfQuantity.ToString());
        }

        public eFuelType FuelType
        {
            get { return m_fuelType; }
            set { m_fuelType = value; }
        }

        public override void FuleVehicle(float i_quantityToAdd) // this function fual the vehicle
        {
            float currentAmountOfFuelInLiters = CurrentEngineQuantity;  // get the CurrentEngineQuantity from the engine
            float maxAmountOfFuelInLiters = MaxEngineQuantity; // get the MaxEngineQuantity from the engine

            if (currentAmountOfFuelInLiters + i_quantityToAdd > maxAmountOfFuelInLiters) // If add the quantity that user requested exceeds the maximum
            {
                throw new ValueOutOfRangeException(0, (maxAmountOfFuelInLiters - currentAmountOfFuelInLiters));
            }
            else // we can add the quantity the user requested
            {
                CurrentEngineQuantity =currentAmountOfFuelInLiters + i_quantityToAdd;  // updeate the current engine quantity
            }
        }

        public override List<string> QuestionsForEngine() // this function hold the list of quastion that related to the gasolin engine
        {
            List<string> QuestionsForEngine = new List<string>();
            QuestionsForEngine.Add("Please enter the current amount of fuel in liters and press 'Enter' ");
            return QuestionsForEngine;
        }

        public override void CheckInputAndUpdateForEngine(string i_input, int i_numberOfQuestion) // this function check the input from user according to the question number
        {
            switch (i_numberOfQuestion)
            {
                case 1:  // question number 1
                    {
                        CheckCurrentFuel(i_input); // call to function that check the current fuel input and update the data member
                        break;
                    }
            }
        }

        public void checkAndUpdateFuelType(string i_input) // this function check the fuel type input and update the data member
        {
            m_fuelType = CheckFuelType(i_input); // call to function that check the fual type
        }

        public eFuelType CheckFuelType(string i_input) // this function check the fual type
        {
            eFuelType fuelType;
            try
            {
                fuelType = (eFuelType)Enum.Parse(typeof(eFuelType), i_input); // try to parss the fual type to enum
            }
            catch (ArgumentException Ex)
            {
                throw new ArgumentException("You have to choose one of the following: <SOLER,OCTAN95,OCTAN96,OCTAN98>");
            }
            return fuelType;
        }

        public void CheckMaxFuel(string i_input) // this function check the max fuel input and update the data member
        {
            bool correctInput; // a boolean variable that checks whether the input from the user is correct
            float maxFuel;

            correctInput = float.TryParse(i_input, out maxFuel); // try to parss to float
            if (!correctInput) // if the input from the user isnt correct
            {
                throw new FormatException("The input supposed to be only numbers");
            }
            MaxEngineQuantity = maxFuel;
        }

        public void CheckCurrentFuel(string i_input) // this function check the current fuel input and update the data member
        {
            bool correctInput;  // a boolean variable that checks whether the input from the user is correct
            float currentFuel;

            correctInput = float.TryParse(i_input, out currentFuel); // try to parss to float
            if (!correctInput) // if the input from the user isnt correct
            {
                throw new FormatException("The input supposed to be only numbers");
            }
            else if (currentFuel > MaxEngineQuantity) // if the currentFuel input is too big
            {
                throw new ArgumentException("The current Engine Quantity have to be lass then the max Engine Quantity");
            }
            CurrentEngineQuantity = currentFuel;
        }

        public override void GetDetailesEngine(List<string> io_listOfDetailes)  // this function add the gasolin engine detailes to the list
        {
            io_listOfDetailes.Add(string.Format("Type of fule :{0}", m_fuelType.ToString()));
            io_listOfDetailes.Add(string.Format("Max fule :{0}", MaxEngineQuantity.ToString()));
            io_listOfDetailes.Add(string.Format("Current fuel:{0}", CurrentEngineQuantity.ToString()));
        }
    }
}
