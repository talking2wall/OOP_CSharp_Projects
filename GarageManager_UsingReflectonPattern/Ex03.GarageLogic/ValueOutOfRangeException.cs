using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_maxValue;
        private float m_minValue;

        public float MaxValue
        {
            get { return m_maxValue; }
        }

        public float MinValue
        {
            get { return m_minValue; }
        }

        public ValueOutOfRangeException(float i_minValue, float i_maxValue)
        : base(string.Format("An error occured while trying to set the value, the allowed range is {0} to {1}.", i_minValue, i_maxValue))
        {
            m_maxValue = i_maxValue;
            m_minValue = i_minValue;
        }
    }
}
