using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private enum eLicenseType { A, AB, A2, B1}; // Types of licenses
        private eLicenseType m_licenseType;
        int m_engineVolumeInCC;

        public Motorcycle(int numberOfWheel, float i_maxAirPressure, string i_typeOfengine, float i_maxOfQuantity, string i_typeOfGasolin = "NONE") : base(numberOfWheel, i_maxAirPressure, i_typeOfengine, i_maxOfQuantity, i_typeOfGasolin) { }

        public override List<string> QuestionsForAllVehicles() // this function hold the list of quastion that related to the Motorcycle
        {
            List<string> QuestionsForMotorcycle = new List<string>();
            QuestionsForMotorcycle.Add("Please enter the license type and press 'Enter' ");
            QuestionsForMotorcycle.Add("Please enter the engine volume in CC and press 'Enter' ");
            return QuestionsForMotorcycle;
        }

        public override void CheckInputAndUpdateForAllVehicles(string i_input, int i_numberOfQuestion) // this function check the input from user according to the question number
        {
            switch (i_numberOfQuestion)
            {
                case 1: // question number 1
                    {
                        CheckLicensTypeAndUpdate(i_input); // call to function that check the license type input and updeate the data member
                        break;
                    }
                case 2: // question number 2
                    {
                        CheckEngineVolumeAndUpdate(i_input); // call to function that check the engine volume input and updeate the data member
                        break;
                    }
            }
        }

        public void CheckLicensTypeAndUpdate(string i_input) // this function check the license type input and updeate the data member
        {
            try
            {
                m_licenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), i_input); // try to parss the license type to enum
            }
            catch (ArgumentException Ex)
            {
                throw new ArgumentException("You have to choose one of the following licens type: <A,AB,A2,B1>");
            }
        }

        public void CheckEngineVolumeAndUpdate(string i_input) // this function check the engine volume input and updeate the data member
        {
            bool correctInput; // a boolean variable that checks whether the input from the user is correct
            int EngineVolume;

            correctInput = int.TryParse(i_input, out EngineVolume); // try to parss the EngineVolume input to int
            if (!correctInput) // if input from the user isnt correct
            {
                throw new FormatException("the input supposed to be a Integer");
            }
            m_engineVolumeInCC = EngineVolume;
        }

        public override void GetDetailesOwnerVehicle(List<string> io_listOfDetailes) // this function add the Motorcycle detailes to the list
        {
            GetDetailesVehicle(io_listOfDetailes);
            io_listOfDetailes.Add(string.Format("License Type:{0}", m_licenseType.ToString()));
            io_listOfDetailes.Add(string.Format("Engine Volume In CC:{0}", m_engineVolumeInCC.ToString()));
        }
    }

}
