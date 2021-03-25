using System;

namespace Ex03.GarageLogic
{

    // $G$ DSN-001 (-10) There is no appropriate use of polymorphism. - this why so many parameters in the constructor
    public abstract class Car : Vehicle
     {
          [Flags]
          public enum eColor
          {
               None,
               Red,
               Blue,
               Black,
               Gray
          }

          [Flags]
          public enum eNumberOfDoors
          {
               None,
               Two = 2,
               Three,
               Four,
               Five
          }

          public const int k_NumberOfWheels = 4;
          public const float k_MaximalAirPressure = 31;
          private eColor m_Color;
          private eNumberOfDoors m_NumberOfDoors;

          public Car(
               Owner i_Owner, string i_Model, string i_LicenceNumber, Tank i_Tank, Wheel[] i_Wheels, eColor i_Color, eNumberOfDoors i_NumberOfDoors)
               : base(i_Owner, i_Model, i_LicenceNumber, i_Tank, i_Wheels)
          {
               m_Color = i_Color;
               m_NumberOfDoors = i_NumberOfDoors;               
          }

          public override string ToString()
          {
               string carString;

               carString = base.ToString() + string.Format("\nColor: {0}\nNumber of doors: {1}", m_Color, m_NumberOfDoors);

               return carString;
          }
     }
}
