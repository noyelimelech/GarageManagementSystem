using System;

namespace Ex03.GarageLogic
{
     public class GasTank : Tank
     {
          [Flags]
          public enum eGasType
          {
               None,
               Soler,
               Octan95,
               Octan96,
               Octan98
          }

          private eGasType m_GasType;

          public eGasType GasType
          {
               get
               {
                    return m_GasType;
               }
          }

          public GasTank(float i_CurrentAmount, float i_MaximalAmount, eGasType i_GasType) : base(i_CurrentAmount, i_MaximalAmount)
          {
               m_GasType = i_GasType;
          }

          public void LoadGasTank(float i_AmountToLoad, eGasType i_GasType)
          {
               if (i_GasType == m_GasType) 
               {                   
                    LoadTank(i_AmountToLoad);
               }
               else
               {
                    throw new ArgumentException(string.Format("Wrong gas type. The right one is {0}", m_GasType.ToString()));
               }
          }

          public override string ToString()
          {
               string gasTank;

               gasTank = string.Format("\nGas tank:\nGas type: {0}", m_GasType) + base.ToString();

               return gasTank;
          }
     }
}