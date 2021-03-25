namespace Ex03.GarageLogic
{
     public class GasCar : Car
     {
          public const GasTank.eGasType k_GasType = GasTank.eGasType.Octan96;
          public const float k_MaximalTankSize = 55;

          public GasCar(Owner i_Owner, string i_Model, string i_LicenceNumber, GasTank i_GasTank, Wheel[] i_Wheels, eColor i_Color, eNumberOfDoors i_NumberOfDoors)
               : base(i_Owner, i_Model, i_LicenceNumber, i_GasTank, i_Wheels, i_Color, i_NumberOfDoors)
          {
          }

          public override string ToString()
          {
               return "\nGas car:" + base.ToString();
          }
     }
}
