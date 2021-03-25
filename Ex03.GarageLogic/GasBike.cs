namespace Ex03.GarageLogic
{
     public class GasBike : Bike
     {
          public const GasTank.eGasType k_GasType = GasTank.eGasType.Octan95;
          public const float k_MaximalTankSize = 8;

          public GasBike(
               Owner i_Owner, string i_Model, string i_LicenceNumber, GasTank i_GasTank, Wheel[] i_Wheels, eLicenceType i_LicenceType, int i_EngineVolume) 
               : base(i_Owner, i_Model, i_LicenceNumber, i_GasTank, i_Wheels, i_LicenceType, i_EngineVolume)
          {
          }

          public override string ToString()
          {
               return "\nGas bike:" + base.ToString();
          }
     }
}
