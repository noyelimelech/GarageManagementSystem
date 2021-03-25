using System;

namespace Ex03.GarageLogic
{
     public class VehicleCardInGarage
     {
          [Flags]
          public enum eVehicleStatus
          {
               None,
               InFixingProccess,
               Fixed,
               Payed
          }

          private eVehicleStatus m_VehicleStatus = eVehicleStatus.InFixingProccess;
          private Vehicle m_VehicleInGarage;

          public Vehicle Vehicle
          {
               get
               {
                    return m_VehicleInGarage;
               }
          }

          public eVehicleStatus VehicleStatus
          {
               get
               {
                    return m_VehicleStatus;
               }

               set 
               {
                    m_VehicleStatus = value;
               }
          }

          public VehicleCardInGarage(Vehicle i_VehicleInGarage)
          {
               m_VehicleInGarage = i_VehicleInGarage;
          }

          public override string ToString()
          {
               string stringOfVehicleCard;

               stringOfVehicleCard = m_VehicleInGarage.ToString() + "\nStatus in garage: ";
               if (m_VehicleStatus == eVehicleStatus.InFixingProccess) 
               {
                    stringOfVehicleCard += "In fixing proccess";
               }
               else
               {
                    stringOfVehicleCard += m_VehicleStatus.ToString();
               }

               return stringOfVehicleCard;
          }
     }
}
