using System.Collections.Generic;

namespace Ex03.GarageLogic
{
     public class Garage
     {
          private Dictionary<string, VehicleCardInGarage> m_VehicleInGarage = new Dictionary<string, VehicleCardInGarage>();

          public VehicleCardInGarage GetVehicleCardByLicenceNumber(string i_LicenceNumber)
          {
               VehicleCardInGarage vehicleCardInGarage;
               m_VehicleInGarage.TryGetValue(i_LicenceNumber, out vehicleCardInGarage);
               return vehicleCardInGarage;
          }

          public bool IsVehicleExistsInGarage(string i_LicenceNumber)
          {
               return m_VehicleInGarage.ContainsKey(i_LicenceNumber);
          }

          public void EnterVehicleToGarage(VehicleCardInGarage i_VehicleCardToEnter, string i_LicenceNumber)
          {
               m_VehicleInGarage.Add(i_LicenceNumber, i_VehicleCardToEnter);
          }

          public List<string> GetArrayOfLicenceNumberByStatus(VehicleCardInGarage.eVehicleStatus i_UserVehicleStatus)
          {
               List<string> arrayOfLicenceNumberByStatus = new List<string>();

               foreach (KeyValuePair<string, VehicleCardInGarage> vehicleCard in m_VehicleInGarage)
               {
                    if(vehicleCard.Value.VehicleStatus == i_UserVehicleStatus)
                    {
                         arrayOfLicenceNumberByStatus.Add(vehicleCard.Key);
                    }
               }

               return arrayOfLicenceNumberByStatus;
          }

          public List<string> GetArrayOfAllLicenceNumber()
          {
               List<string> arrayOfLicenceNumber = new List<string>();
               VehicleCardInGarage.eVehicleStatus vehicleStatus;

               for (int i = 1; i <= 3; i++) 
               {
                    vehicleStatus = (VehicleCardInGarage.eVehicleStatus)i;
                    arrayOfLicenceNumber.AddRange(GetArrayOfLicenceNumberByStatus(vehicleStatus));
               }

               return arrayOfLicenceNumber;
          }
     }
}