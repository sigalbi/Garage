using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private float m_currentEngineQuantity;
        private float m_maxEngineQuantity;
        public Engine(float i_maxOfQuantit)
        {
            m_maxEngineQuantity = i_maxOfQuantit;
        }
        public abstract void FuleVehicle(float i_quantityToAdd); // a abstract fual function

        public float CurrentEngineQuantity
        {
            get { return m_currentEngineQuantity; }
            set { m_currentEngineQuantity = value; }
        }

        public float MaxEngineQuantity
        {
            get { return m_maxEngineQuantity; }
            set { m_maxEngineQuantity = value; }
        }

        public abstract List<string> QuestionsForEngine();  // a abstract questions function
        public abstract void CheckInputAndUpdateForEngine(string i_input, int i_numberOfQuestion); // a abstract check and updeate function
        public abstract void GetDetailesEngine(List<string> io_listOfDetailes); // a abstract function that add the engine detailes to list
    }
}
