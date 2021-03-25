using System;

namespace Ex03.GarageLogic
{
     public abstract class Bike : Vehicle
     {
          [Flags]
          public enum eLicenceType
          {
               None,
               A,
               A1,
               A2,
               B
          }

          public const int k_NumberOfWheels = 2;
          public const float k_MaximalAirPressure = 33;
          private eLicenceType m_LicenceType;
          private int m_EngineVolume;

          public Bike(
               Owner i_Owner, string i_Model, string i_LicenceNumber, Tank i_Tank, Wheel[] i_Wheels, eLicenceType i_LicenceType, int i_EngineVolume) 
               : base(i_Owner, i_Model, i_LicenceNumber, i_Tank, i_Wheels)
          {
               m_LicenceType = i_LicenceType;
               m_EngineVolume = i_EngineVolume;               
          }

          public override string ToString()
          {
               string bikeString;

               bikeString = base.ToString() + string.Format("\nLicence type: {0}\nEngine volume: {1}", m_LicenceType, m_EngineVolume);

               return bikeString;
          }
     }
}
