using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageLogics
    {
        private enum ekeyBoard { One = 1, Two, Three, Four, Five, Six, Seven, Esc }; // Set menu keys
        private Dictionary<string, Owner_Details> m_vehicleCollection;

        public GarageLogics()
        {
            m_vehicleCollection = NewObj.NewDictionary();
        }

        public static void CheckUserInputForShowList(string io_inputFromUser) // this function check if the user filter input is legal
        {
            Owner_Details.eVehicleStatus statusOfVehicale;

            if (io_inputFromUser.CompareTo(" ") == 0) // if the input is empty
            {
                throw new ArgumentException("You have to choose one");
            }
            foreach (char letter in io_inputFromUser)
            {
                if (!(letter <= 'Z' && letter >= 'A'))  // if the input isnt in capital latters
                {
                    throw new ArgumentException("The select have to be only capital latters");
                }
            }
            try
            {
                statusOfVehicale = (Owner_Details.eVehicleStatus)Enum.Parse(typeof(Owner_Details.eVehicleStatus), io_inputFromUser); // try to parss the input to enum
            }
            catch (ArgumentException Ex)
            {
                if (io_inputFromUser.CompareTo("NONE") != 0)
                {
                    throw new FormatException("You have to choose one of the following :<NONE, INPROCESS, FIXED, PAIDUP>");
                }
            }
        }

        public float CheckQuantityToFillFromUser(string io_quantityToFillAtFloat) // this function check if the quantity that the user input is currect 
        {
            bool isntParse; // a Boolean variable that tells if the conversion wasnt successful
            float QuantityToFill;

            isntParse = float.TryParse(io_quantityToFillAtFloat, out QuantityToFill);  // try to convert from string to float
            if (!isntParse)  // if conversion failed
            {
                throw new FormatException("You have to enter only numbers");
            }
            return QuantityToFill;
        }

        public void CheckFuleTypeOfVehicle(Owner_Details i_owner, string i_fualType) // this function check if the fual type that user input is currect
        {
            Gasolin.eFuelType enumFulType;
            enumFulType = (Gasolin.eFuelType)Enum.Parse(typeof(Gasolin.eFuelType), i_fualType);
            if (((Gasolin)(i_owner.ownerVehicle.engine)).FuelType != enumFulType)  // if the fual type not suitable for vehicle
            {
                throw new ArgumentException("Fuel type is not suitable for vehicle fueling");
            }
        }

        public static void CheckIfGasolinEngine(Owner_Details i_owner)  // this function check if the vehicle is a gas driven vehicle
        {
            if (!(i_owner.ownerVehicle.engine is Gasolin))  // if its not a gasolin engine
            {
                throw new ArgumentException("The vehicle type is not suitable for refueling");
            }
        }

        public static void CheckIfElectricEngine(Owner_Details i_owner) // this function check if the vehicle is a electric vehicle
        {
            if (!(i_owner.ownerVehicle.engine is Electric))  // if its not a electric engine
            {
                throw new ArgumentException("The vehicle type is not suitable for charging");
            }
        }

        public Owner_Details GetOwner(string i_licenseNumber) // this function returns the vehicle owner's details according to the license number
        {
            Owner_Details owner;
            bool findKey; // a Boolean variable that tells if we found the license number in the garage

            findKey = m_vehicleCollection.TryGetValue(i_licenseNumber, out owner); // Search the license number in the garage
            if (!findKey)  // if we dont found the license number
            {
                throw new ArgumentException("There is no such license number. Please try again..");
            }
            return owner;
        }

        public List<string> ShowListOfVehicles(string i_inputFromUser) // this function shows the list of vehicles according to the filter the user has selected
        {
            List <string> listOfLicense;
            GarageLogics.CheckUserInputForShowList(i_inputFromUser);
            if (i_inputFromUser.CompareTo("NONE") == 0) // If the user did not request to filter
            {
                listOfLicense = AddToListAllLicense();
            }
            else
            {
                listOfLicense = AddToListLicenseSorted(i_inputFromUser);
            }
            return listOfLicense;
        }

        public List<string> AddToListAllLicense() // this function add to the list of vehicles
        {
            List<string> listOfLicense = NewObj.NewList();

            foreach (KeyValuePair<string, Owner_Details> Owners in m_vehicleCollection)
            {
                listOfLicense.Add(Owners.Value.ownerVehicle.lincesNumber);
            }
            return listOfLicense;
        }

        public List<string> AddToListLicenseSorted(string i_inputFromUser) // this function add to the filter list of vehicles
        {
            List<string> listOfLicense = NewObj.NewList();
            Owner_Details.eVehicleStatus statusOfVehicale;
            statusOfVehicale = (Owner_Details.eVehicleStatus)Enum.Parse(typeof(Owner_Details.eVehicleStatus), i_inputFromUser);

            foreach (KeyValuePair<string, Owner_Details> Owners in m_vehicleCollection)
            {
                if (Owners.Value.currentVehicleStatus == statusOfVehicale)
                {
                    listOfLicense.Add(Owners.Value.ownerVehicle.lincesNumber);
                }
            }
            return listOfLicense;
        }

        public void InflateVehicleAirTiresToTheMaximum(string i_inputFromUser) // this function inflate the wheels air to the maximum
        {
            Owner_Details owner;
            Vehicle.CheckLincesNumber(i_inputFromUser);  // check if currect linces number
            owner = GetOwner(i_inputFromUser);  // get the owner details through the linces number
            owner.ownerVehicle.InflateAllWheelToMax(); // call to the function that inflate the air wheels to the vehicle
        }

        public void ChangeVehicleStatus(string i_inputLincesFromUser,string i_InputStatusFromUser) // this function change the vehicle status
        {
            Owner_Details owner;
            Vehicle.CheckLincesNumber(i_inputLincesFromUser); // check if currect linces number
            owner = GetOwner(i_inputLincesFromUser); // get the owner details through the linces number
            owner.UpdeateVehicleStatus(i_InputStatusFromUser); // call to function that updeate that vehicle status
        }

        public void FuelVehicleThatPoweredByFuel(string i_inputLincesFromUser, string i_FualTypeFromUser, string i_QuantityToFillFromUser) // this function check the input for Fuel Vehicle That Powered By Fuel and fual
        {
            float quantityToFillAtFloat;
            Owner_Details owner;

            Vehicle.CheckLincesNumber(i_inputLincesFromUser); // check if currect linces number
            owner = GetOwner(i_inputLincesFromUser); // get the owner details through the linces number
            CheckIfGasolinEngine(owner); // check if its a gasolin vehicle
            ((Gasolin)(owner.ownerVehicle.engine)).CheckFuelType(i_FualTypeFromUser); // check the fual type
            CheckFuleTypeOfVehicle(owner, i_FualTypeFromUser); // call to function that check if the input fual type is currect to the vehicle
            quantityToFillAtFloat = CheckQuantityToFillFromUser(i_QuantityToFillFromUser); // call to function that check if the  quantity input is currect
            owner.ownerVehicle.engine.FuleVehicle(quantityToFillAtFloat); // call to fule function. throw ex if the quantityToFill is too big
            owner.ownerVehicle.updateTheFualPrecent(); //update the precent fuel left    
        }

        public void RechargeElectricVehicle(string i_inputLincesFromUser, string i_QuantityToFillFromUser) // this function check the inputs and charge the vehicle
        {
            float minutesToChargeInFloat;
            Owner_Details owner;

            Vehicle.CheckLincesNumber(i_inputLincesFromUser); // check if currect linces number
            owner = GetOwner(i_inputLincesFromUser); // get the owner details through the linces number
            CheckIfElectricEngine(owner); // check if its a electric vehicle
            minutesToChargeInFloat = CheckQuantityToFillFromUser(i_QuantityToFillFromUser); // check if the  minutes to charge unput is currect
            owner.ownerVehicle.engine.FuleVehicle(minutesToChargeInFloat);  // call to fule function. throw Ex if the quantityToFill is too big
            owner.ownerVehicle.updateTheFualPrecent(); //update the precent fuel left
        }

        public List<string> ShowFullDataOfVehicle(string i_inputLincesFromUser) // this function return a list of full data of a vehicle
        {
            Owner_Details owner;
            List<string> AllDetailsToPrint = NewObj.NewList();

            Vehicle.CheckLincesNumber(i_inputLincesFromUser);
            owner = GetOwner(i_inputLincesFromUser);
            owner.GetDetailesOwner(AllDetailsToPrint);
            return AllDetailsToPrint;
        }

        public bool CheckIfLincesExicetAndTryToUpdate(string i_inputLincesFromUser) // this function checks if the vehicle exists in the system and updates its status to INPROCESS
        {
            Owner_Details ownerDetails;
            bool notFound = true;
            Vehicle.CheckLincesNumber(i_inputLincesFromUser);

            if (m_vehicleCollection.TryGetValue(i_inputLincesFromUser, out ownerDetails))
            {
                notFound = false;
                ownerDetails.currentVehicleStatus = Owner_Details.eVehicleStatus.INPROCESS;
            }
            return notFound;
        }

        public void AddOwnerToGarage (Owner_Details i_newOwner) // this function add a new owner vehicle to garage
        {
            m_vehicleCollection.Add(i_newOwner.ownerVehicle.lincesNumber, i_newOwner);
        }
    }
}
