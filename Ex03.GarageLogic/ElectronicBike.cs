namespace Ex03.GarageLogic
{
     public class ElectronicBike : Bike 
     {
          public const float k_MaximalTankSize = 1.4f;

          public ElectronicBike(
               Owner i_Owner, string i_Model, string i_LicenceNumber, ElectronicTank i_ElectronicTank, Wheel[] i_Wheels, eLicenceType i_LicenceType,  int i_EngineVolume)
               : base(i_Owner, i_Model, i_LicenceNumber, i_ElectronicTank, i_Wheels, i_LicenceType, i_EngineVolume)
          {
          }

          public override string ToString()
          {
               return "\nElectronic bike:" + base.ToString();
          }
     }
}
