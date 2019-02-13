using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_manufacturerName;
        private float m_currentAirPressure;
        private float m_maxAirPressure;

        public Wheel (float i_maxAirPressure)
        {
            m_maxAirPressure = i_maxAirPressure; 
        }

        public bool InflateWheel(float i_airToInflate) // a boolean function that return if successed to fill air in the wheels
        {
            bool succsedToInflate = true; //A Boolean variable that tells if we successed to fill the air with wheels
            if (m_currentAirPressure + i_airToInflate > m_maxAirPressure) // If we exceed the maximum quantity
            {
                succsedToInflate = false;
            }
            else // If we not exceed the maximum quantity
            {
                m_currentAirPressure += i_airToInflate;
            }
            return succsedToInflate;
        }

        public void InflateWheelToMax() // this function inflate the air wheels to the maximum
        {
            m_currentAirPressure = m_maxAirPressure;
        }

        public static List<string> QuestionsForWheel() // this function hold the list of quastion that related to the wheel
        {
            List<string> questionsForVehicle = new List<string>();
            questionsForVehicle.Add("Please enter the name of the wheels manufacturer and press 'Enter' ");
            questionsForVehicle.Add("Please enter the current air pressure in the wheels and press 'Enter' ");
            return questionsForVehicle;
        }

        public void CheckInputAndUpdateForWheel(string i_input, int i_numberOfQuestion)  // this function check the input from user according to the question number
        {
            switch (i_numberOfQuestion)
            {
                case 1: // question number 1
                    {
                        CheckNameWheelsAndUpdate(i_input); // call to function that check the name of the wheels manufacturer input and updeate the data members
                        break;
                    }
                case 2: // question number 2
                    {
                        CheckCurrentAirPressureAndupdate(i_input);  // call to function that check the current air pressure input and updeate the data members
                        break;
                    }
            }
        }

        public void CheckNameWheelsAndUpdate(string i_input) // this function check the name of the wheels manufacturer input and updeate the data members
        {
            if (i_input.CompareTo("") == 0) // if its an empty input
            {
                throw new ArgumentException("You have to type some name");
            }
            foreach (char letter in i_input)
            {
                if (!((letter <= 'z' && letter >= 'a') || (letter <= 'Z' && letter >= 'A') || (letter == ' '))) // If input is not composed of letters and spaces
                {
                    throw new ArgumentException("The name have to be letters only");
                }
            }
            m_manufacturerName = i_input;
        }

        public void CheckMaxAirPressure(string i_input) // this function check the max air pressure input and updeate the data members
        {
            bool correctInput; // a boolean variable that checks whether the input from the user is correct
            float maxFuel;

            correctInput = float.TryParse(i_input, out maxFuel); // try to parss to float
            if (!correctInput) // if the input from the user isnt correct
            {
                throw new FormatException("The input supposed to be only numbers");
            }
            m_maxAirPressure = maxFuel;
        }

        public void CheckCurrentAirPressureAndupdate(string i_input) // this function check the current air pressure input and updeate the data members
        {
            bool correctInput; // a boolean variable that checks whether the input from the user is correct
            float currentFuel;

            correctInput = float.TryParse(i_input, out currentFuel);// try to parss to float
            if (!correctInput)// if the input from the user isnt correct
            {
                throw new FormatException("The input supposed to be only numbers");
            }
            else if (currentFuel > m_maxAirPressure) // if the correctInput is too big
            {
                throw new ArgumentException("The current air pressure have to be lass then the max air pressure");
            }
            m_currentAirPressure = currentFuel;
        }

        public void GetDetailesWhell(List<string> io_listOfDetailes) // this function add the wheel detailes to the list
        {
            io_listOfDetailes.Add(string.Format("Manufacturer Name:{0}", m_manufacturerName));
            io_listOfDetailes.Add(string.Format("Max Air Pressure:{0}", m_maxAirPressure));
            io_listOfDetailes.Add(string.Format("Current Air Pressure:{0}", m_currentAirPressure));
        }
    }
}
