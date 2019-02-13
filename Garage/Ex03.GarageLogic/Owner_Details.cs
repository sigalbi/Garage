using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Owner_Details
    {
        public enum eVehicleStatus { INPROCESS, FIXED, PAIDUP }; // Status types
        private string m_ownerName;
        private string m_ownerPhoneNumber;
        private Vehicle m_ownerVehicle;
        private eVehicleStatus m_currentVehicleStatus;

        public Owner_Details()
        {
            m_currentVehicleStatus = eVehicleStatus.INPROCESS;
        }

        public eVehicleStatus currentVehicleStatus
        {
            get { return m_currentVehicleStatus; }
            set {  m_currentVehicleStatus = value;  }
        }

        public Vehicle ownerVehicle
        {
            get { return m_ownerVehicle; }
            set { m_ownerVehicle = value; }
        }
        public string ownerName
        {
            get { return m_ownerName; }
            set { m_ownerName = value; }
        }
        public string ownerPhoneNumber
        {
            get { return m_ownerPhoneNumber; }
            set { m_ownerPhoneNumber = value; }
        }
        public List<string> QuestionsForOwner() // this function hold the list of quastion that related to the Owner Details
        {
            List<string> questionsForOwner = new List<string>();
            questionsForOwner.Add("Please enter the owner's name and press 'Enter' ");
            questionsForOwner.Add("Please enter the phone number of the owner and press 'Enter' ");
            return questionsForOwner;

        }

        public void CheckOwnerDetailsInput(string i_input, int i_numberOfQuestion) // this function check the input from user according to the question number
        {
            switch (i_numberOfQuestion)
            {
                case 1: // question number 1
                    {
                       CheckOwnersName(i_input); // call to function that check the owner's name input and update the data members
                        break;
                    }
                case 2: // question number 2
                    {
                        CheckOwnersPhone(i_input); // call to function that check the phone number input and update the data members
                        break;
                    }
            }
        }

        public bool updateOwnerDetailsInput(string i_input, int i_numberOfQuestion) // this function updeate the Owner Details members
        {
            bool correctInput = true;  // a boolean variable that checks whether the input from the user is correct

            switch (i_numberOfQuestion)
            {
                case 1: // question number 1
                    {
                        m_ownerName = i_input; // updeate the data member
                        break;
                    }
                case 2: // question number 2
                    {
                        m_ownerPhoneNumber = i_input; // updeate the data member
                        break;
                    }
            }
            return correctInput;
        }

        public void CheckOwnersName(string i_input) // this function check the Owners Name input and update the data members
        {
            if (i_input.CompareTo("") == 0) // if its an empty input
            {
                throw new ArgumentException("You have to write owner name ");
            }
            foreach (char letter in i_input)
            {
                if(!((letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z') || (letter == ' '))) // If input is not composed of letters and spaces
                {
                    throw new ArgumentException("The name have to be only latters");
                }
            }
        }

        public void CheckOwnersPhone(string i_input) // this function check the Owners Phone input and update the data members
        {
            if (i_input.CompareTo("") == 0) // if its an empty input
            {
                throw new ArgumentException("You have to write phone number");
            }
            foreach (char letter in i_input)
            {
                if (!(letter <= '9' && letter >= '0')) // If the input is not composed of numbers only
                {
                    throw new ArgumentException("The number have to be only numbers");
                }
            }
        }

        public void UpdeateVehicleStatus(string i_statusInput) // this function updeate the vehicle status according to user input
        {
            try
            {
                m_currentVehicleStatus = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), i_statusInput); // try to parss the input to enum
            }
            catch (ArgumentException Ex)
            {
                throw new ArgumentException("You have to choose one of the follwoing status: INPROCESS, FIXED, PAIDUP");
            }
        }

        public void GetDetailesOwner(List<string> io_listOfDetailes) // this function add the Owner detailes to the list
        {
            io_listOfDetailes.Add(string.Format("Name:{0}", m_ownerName));
            io_listOfDetailes.Add(string.Format("phone:{0}", m_ownerPhoneNumber));
            io_listOfDetailes.Add(string.Format("Current Vehicle Status:{0}", m_currentVehicleStatus.ToString()));
            m_ownerVehicle.GetDetailesOwnerVehicle(io_listOfDetailes);
        }
    }
}
