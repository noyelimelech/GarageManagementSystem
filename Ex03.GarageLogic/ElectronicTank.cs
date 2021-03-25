namespace Ex03.GarageLogic
{
     public class ElectronicTank : Tank 
     {
          public ElectronicTank(float i_CurrentAmount, float i_MaximalAmount) : base(i_CurrentAmount, i_MaximalAmount)
          {
          }

          public void LoadElectronicTank(float i_AmountToLoad)
          {
               LoadTank(i_AmountToLoad);
          }

          public override string ToString()
          {
               return "\nElectronic tank:" + base.ToString();
          }
     }
}
