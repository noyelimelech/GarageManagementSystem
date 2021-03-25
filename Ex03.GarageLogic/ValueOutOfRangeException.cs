﻿using System;

namespace Ex03.GarageLogic
{
     public class ValueOutOfRangeException : Exception
     {          
          private float m_MaxValue;
          private float m_MinValue;          
    
          public float MaxValue
          {
               get
               {
                    return m_MaxValue;
               }
          }

          public float MinValue
          {
               get
               {
                    return m_MinValue;
               }
          }

          public ValueOutOfRangeException(Exception i_InnerException, float i_MinValue, float i_MaxValue)
               : base(string.Format("Wrong value. The value must be between {0} to {1}", i_MinValue, i_MaxValue), i_InnerException)               
          {
               m_MinValue = i_MinValue;
               m_MaxValue = i_MaxValue;
          }
     }
}
