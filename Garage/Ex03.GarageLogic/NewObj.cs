using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class NewObj
    {
        public static Vehicle NewVehicle(string i_typeOfvehicle) // this function Creates a new vehicle according to the type the user typed
        {
            Vehicle newVhicle;
            
            if (i_typeOfvehicle.CompareTo("electric car") == 0)
            {
                newVhicle = new Car(4,30, i_typeOfvehicle.Split(' ')[0], 2.5f); // Create an electric car
            }
            else if (i_typeOfvehicle.CompareTo("electric motorcycle") == 0)
            {
                newVhicle = new Motorcycle(2,33, i_typeOfvehicle.Split(' ')[0], 2.7f); // Create an electric motorcycle
            }
            else if (i_typeOfvehicle.CompareTo("gasolin car") == 0)
            {
                newVhicle = new Car(4,30, i_typeOfvehicle.Split(' ')[0], 42, "OCTAN98"); // Create gasolin car
            }
            else if (i_typeOfvehicle.CompareTo("gasolin motorcycle") == 0)
            {
                newVhicle = new Motorcycle(2,33, i_typeOfvehicle.Split(' ')[0], 5.5f, "OCTAN95"); // Create gasolin motorcycle
            }
            else if (i_typeOfvehicle.CompareTo("truck") == 0)
            {
                newVhicle = new Truck(12,32,"gasolin", 135f, "OCTAN96"); // Create truck
            }
            else // If it is a type that does not exist in the system
            {
                newVhicle = null;
                throw new ArgumentException("You have to choose one of the following <electric car,electric motorcycle,gasolin car,gasolin motorcycle,truck>");
            }
            return newVhicle; 
        }

        public static Wheel [] MAkeNewWeels(int i_numberOfWheels , float i_maxAirPressure) // this function creates the wheels array of the vehicle
        {
            Wheel []  wheels = new Wheel[i_numberOfWheels];
            for(int i=0; i< i_numberOfWheels;i++)
            {
                wheels[i] = new Wheel(i_maxAirPressure);
            }
            return wheels;
        }

        public static Owner_Details NewOwnerDetails() // this function create newOwner vehicle
        {
            Owner_Details newOwner = new Owner_Details();
            return newOwner;
        }

        public static Engine NewEngine(string i_typeOfEngine ,float i_maxOfQuantity, string i_typeOfGasolin)   // this function create newEngine 
        {
            Engine newEngine;
            if (i_typeOfEngine.CompareTo("electric") == 0)
            {
                newEngine = new Electric(i_maxOfQuantity); // create an electric engine
            }
            else if (i_typeOfEngine.CompareTo("gasolin") == 0)
            {
                newEngine = new Gasolin(i_maxOfQuantity, i_typeOfGasolin); // create gasolin engine
            }
            else // If the engine type is not specified
            {
                newEngine = null;
            }
            return newEngine;
        }

        public static List<string> NewList() // this function create new list
        {
            List<string> newList = new List<string>();
            return newList; 
        }

        public static Dictionary<string, Owner_Details> NewDictionary() // this function create New Dictionary
        {
            Dictionary<string,Owner_Details> newDictionary = new Dictionary<string, Owner_Details>();
            return newDictionary;
        }

        public static GarageLogics NewGarageLogics()
        {
            GarageLogics newGarageLogics = new GarageLogics();
            return newGarageLogics;
        }
    }
}
