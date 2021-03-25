using System;

namespace Ex03.GarageLogic
{
     public class Wheel
     {
          private string m_MakerName;
          private float m_CurrentAirPresure;


          // $G$ DSN-999 (-4) The "maximum air pressure" field should be readonly member of class wheel.
        private float m_MaximalAirPresure;

          public Wheel(string i_MakerName, float i_CurrentAirPresure, float i_MaximalAirPresure)
          {
               if (i_MaximalAirPresure > 0 || i_CurrentAirPresure <= i_MaximalAirPresure || i_CurrentAirPresure >= 0) 
               {
                    m_MakerName = i_MakerName;
                    m_MaximalAirPresure = i_MaximalAirPresure;
                    m_CurrentAirPresure = i_CurrentAirPresure;
               }
               else
               {
                    throw new ArgumentException("Wrong amounts. The maximal must be positive " + ". current amounst >= 0" +
                         "and the current cant be bigger than the maximal");
               }
          }

          public void LoadAir(float i_AmountToLoad)
          {
               if (m_CurrentAirPresure + i_AmountToLoad <= m_MaximalAirPresure)
               {
                    m_CurrentAirPresure += i_AmountToLoad;
               }
               else
               {
                    throw new ValueOutOfRangeException(null, 0, m_MaximalAirPresure - m_CurrentAirPresure);
               }
          }

          public void LoadAirPressureToMaximum()
          {
               m_CurrentAirPresure = m_MaximalAirPresure;
          }

          public override string ToString()
          {
               string wheelString;

               wheelString = string.Format("\nMaker name: {0}\nCurrent air pressure: {1}\nMaximal air pressure: {2}", m_MakerName, m_CurrentAirPresure, m_MaximalAirPresure);

               return wheelString;
          }
     }
}
