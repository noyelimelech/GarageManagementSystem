namespace Ex03.GarageLogic
{
     public class ElectronicCar : Car
     {
          public const float k_MaximalTankSize = 1.8f;

          public ElectronicCar(
               Owner i_Owner, string i_Model, string i_LicenceNumber, ElectronicTank i_ElectronicTank, Wheel[] i_Wheels, eColor i_Color, eNumberOfDoors i_NumberOfDoors)
               : base(i_Owner, i_Model, i_LicenceNumber, i_ElectronicTank, i_Wheels, i_Color, i_NumberOfDoors)
          {
          }

          public override string ToString()
          {
               return "\nElectronic car:" + base.ToString();
          }
     }
}
