using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_modelName;
        private string m_lincesNumber;
        private float m_energyPrecentLeft;
        private Wheel [] wheels;
        private Engine m_engine; 

        public Vehicle (int numberOfWheel, float i_maxAirPressure, string i_typeOfengine, float i_maxOfQuantity, string i_typeOfGasolin = "NONE")
        {
            m_engine = NewObj.NewEngine(i_typeOfengine, i_maxOfQuantity, i_typeOfGasolin);
            wheels = NewObj.MAkeNewWeels(numberOfWheel, i_maxAirPressure);
        }

        public void UpdateWheels(string i_input, int i_numberOfQuestion) // this function updeate the wheels array
        {
            for(int i=0;i<wheels.Length;i++)
            {
                wheels[i].CheckInputAndUpdateForWheel(i_input, i_numberOfQuestion);
            }
        }

        public abstract List<string> QuestionsForAllVehicles(); // an abstract function that hold the list of quastion that related to the vehicle
        public abstract void CheckInputAndUpdateForAllVehicles(string i_input, int i_numberOfQuestion); // an abstract function that check user inputs acocrding to number of quastion
        public abstract void GetDetailesOwnerVehicle(List<string> io_listOfDetailes); // an abstract function that add the vehicle detailes to the list

        public Engine engine
        {
            get { return m_engine; }
            set { m_engine = value; }
        }

        public string lincesNumber
        {
            get { return m_lincesNumber; }
            set
            {
                CheckLincesNumber(value);
                m_lincesNumber = value;
            }
        }

        public string ModelName
        {
            get { return m_modelName; }
            set
            {
                CheckModelName(value);
                m_modelName = value;
            }
        }

        public static List<string> QuestionsForVehicle() // this function hold the vehicle quastion
        {
            List <string> questionsForVehicle = new List <string> ();
           
            questionsForVehicle.Add("Please enter the model name and press 'Enter' ");
            return questionsForVehicle; 
        }

        public void CheckVehicleInput(string i_input, int i_numberOfQuestion)  // this function check the input from user according to the question number
        {
            switch (i_numberOfQuestion)
            {
                case 1: // question number 1
                    {
                        CheckModelName(i_input); // call to function that check the model name input and updeate the data members
                        break;
                    }
                case 2: // question number 2
                    {
                         CheckLincesNumber(i_input); // call to function that check the LincesNumber input and updeate the data members
                        break;
                    }
            }
        }

        public bool UpdateVehicleInput(string i_input, int i_numberOfQuestion) // this function updeate the vehicle data members according of number of question
        {
            bool correctInput = true;// a boolean variable that checks whether the input from the user is correct

            switch (i_numberOfQuestion)
            {
                case 1: // question number 1
                    {
                        m_modelName = i_input; // updeate data member
                        break;
                    }
                case 2: // question number 2
                    {
                        m_lincesNumber = i_input; // updeate data member
                        break;
                    }
            }
            return correctInput;
        }

        public void CheckModelName(string i_input) // this function check the Model Name input
        {
            if (i_input.CompareTo("") == 0) // if its an empty input
            {
                throw new ArgumentException("You have to write some model name");
            }
            foreach (char letter in i_input)
            {
                if (!((letter <= 'z' && letter >= 'a') || (letter <= 'Z' && letter >= 'A') || (letter == ' ')))// If input is not composed of letters and spaces
                {
                    throw new ArgumentException("The name have to be only latters");
                }
            }
        }

        public static void CheckLincesNumber(string i_input) // this function check the Linces Number input
        {
            if (i_input.CompareTo("") == 0) // if its an empty input
            {
                throw new ArgumentException("You have to write some linces number");
            }
            foreach (char letter in i_input)
            {
                if (!(letter <= '9' && letter >= '0')) // If the input is not composed of numbers only
                {
                    throw new ArgumentException("The linces have to be only numbers");
                }
            }
        }

        public void InflateAllWheelToMax() // this function inflate all whells in the vehicle to the naximum
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].InflateWheelToMax();
            }
        }

        public void GetDetailesVehicle(List<string> io_listOfDetailes) // this function add the vehicle detailes to the list
        {
            io_listOfDetailes.Add(string.Format("Model name:{0}", m_modelName));
            io_listOfDetailes.Add(string.Format("Linces number:{0}", m_lincesNumber));
            io_listOfDetailes.Add(string.Format("Number of wheels:{0}", wheels.Length.ToString()));
            wheels[0].GetDetailesWhell(io_listOfDetailes);
            m_engine.GetDetailesEngine(io_listOfDetailes);
            io_listOfDetailes.Add(string.Format("Energy Precent Left:{0}", m_energyPrecentLeft.ToString()));
        }

        public void updateTheFualPrecent() // this function updeate the Fual Precent data member
        {
            m_energyPrecentLeft = engine.CurrentEngineQuantity / engine.MaxEngineQuantity * 100; 
        }
    }
}
