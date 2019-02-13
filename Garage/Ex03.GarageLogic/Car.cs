using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private enum eColor { YELLOW, WHITE, BLACK, BLUE }; // A variable that holds the colors of cars
        private enum eNumberOfDoors { TWO=2, THREE=3, FOUR=4, FIVE=5}; // A Variable that holds the number of doors in the car
        private eColor m_colorCar;
        private eNumberOfDoors m_numberOfDoors;

        public Car(int numberOfWheel,float i_maxAirPressure, string i_typeOfengine,float i_maxOfQuantity, string i_typeOfGasolin = "NONE") : base(numberOfWheel, i_maxAirPressure, i_typeOfengine, i_maxOfQuantity, i_typeOfGasolin) { }  

        public override List<string> QuestionsForAllVehicles() // this function hold the list of quastion that related to the car
        {
            List<string> QuestionsForCar = new List<string>();
            QuestionsForCar.Add("Please enter the car color <YELLOW, WHITE, BLACK, BLUE> and press 'Enter' ");
            QuestionsForCar.Add("Please enter the number of doors <TWO, TREE, FOUR, FIVE> and press 'Enter' ");
            return QuestionsForCar;
        }

        public override void CheckInputAndUpdateForAllVehicles(string i_input, int i_numberOfQuestion) // this function check the input from user according to the question number
        {
            switch (i_numberOfQuestion)
            {
                case 1:  // question number 1
                    {
                        CheckColorAndUpdate(i_input); // call to function that check the color input and updeate the data members
                        break;
                    }
                case 2:  // question number 2
                    {
                        CheckNumberOfDoorsAndUpdate(i_input); // call to function that check the number of doors input and updeate the data members
                        break;
                    }
            }
        }

        public void CheckColorAndUpdate(string i_input) // this function check the color input and updeate the data member
        {
            try
            {
                m_colorCar = (eColor)Enum.Parse(typeof(eColor), i_input);  // if the color input from the user is a legal input - updeate the data member
            }
            catch (ArgumentException Ex)
            {
                throw new ArgumentException("You have to choose one of the following color: <YELLOW, WHITE, BLACK, BLUE>");
            }
        }

        public void CheckNumberOfDoorsAndUpdate(string i_input) // this function check the number of doors input and updeate the data member
        {
            try
            {
                m_numberOfDoors = (eNumberOfDoors)Enum.Parse(typeof(eNumberOfDoors), i_input); // if the number of doors input from the user is a legal input - updeate the data member
                if (m_numberOfDoors < eNumberOfDoors.TWO || m_numberOfDoors> eNumberOfDoors.FIVE) 
                {
                    throw new ArgumentException();
                }
            }
            catch (ArgumentException Ex)
            {
                throw new ArgumentException("You have to choose one of the following: <TWO, TREE, FOUR, FIVE>");
            }
        }

        public override void GetDetailesOwnerVehicle(List<string> io_listOfDetailes)  // this function add the car detailes to the list
        {
            GetDetailesVehicle(io_listOfDetailes);
            io_listOfDetailes.Add(string.Format("Color:{0}", m_colorCar.ToString()));
            io_listOfDetailes.Add(string.Format("Number Of Doors:{0}", m_numberOfDoors.ToString()));
        }
    }
}
