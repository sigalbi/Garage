using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float maxValue;
        private float minValue;

        public ValueOutOfRangeException(
            Exception i_InnerException,
            float i_MaxValue,
            float i_MinValue)
            : base(string.Format("The range of values is between {0} to {1}", i_MinValue, i_MaxValue), i_InnerException)
        {
            maxValue = i_MaxValue;
            minValue = i_MinValue;
        }

        public ValueOutOfRangeException(
            float i_MaxValue,
            float i_MinValue)
            : base(string.Format("The range of values is between {0} to {1}", i_MaxValue, i_MinValue))
        {
            maxValue = i_MaxValue;
            minValue = i_MinValue;
        }
    }
}
