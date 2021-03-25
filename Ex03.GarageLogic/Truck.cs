namespace Ex03.GarageLogic
{

    // $G$ DSN-999 (-10) Truck is no different from GasCar or GasBike
    // $G$ NTT-999 (-5) You should have use: Environment.NewLine instead of "\n".
    public class Truck : Vehicle
     {
          public const int k_NumOfWheels = 12;
          public const float k_MaximalAirPressure = 26;
          public const GasTank.eGasType k_GasType = GasTank.eGasType.Soler;
          public const float k_MaximalTankSize = 110;
          private bool m_IsThereDangerousMatirial;
          private float m_BaggaeVolume;

          public Truck(Owner i_Owner, string i_Model, string i_LicenceNumber, GasTank i_GasTank, Wheel[] i_Wheels, bool i_IsThereDangerousMatirial, float i_BaggaeVolume)
               : base(i_Owner, i_Model, i_LicenceNumber, i_GasTank, i_Wheels)
          {
               m_BaggaeVolume = i_BaggaeVolume;
               m_IsThereDangerousMatirial = i_IsThereDangerousMatirial;
          }


          // $G$ NTT-999 (-5) You should have use: Environment.NewLine instead of "\n".
        public override string ToString()
          {
               string truckString;

               truckString = "\nTruck" + base.ToString(); 
               if(m_IsThereDangerousMatirial)
               {
                    truckString += "\nThere is dangerous metirials";
               }
               else
               {
                    truckString += "\nThere isn't dangerous metirials";
               }

               truckString += string.Format("\nBaggae volume: {0}", m_BaggaeVolume);

               return truckString;
          }
     }
}
