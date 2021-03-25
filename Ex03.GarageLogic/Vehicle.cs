namespace Ex03.GarageLogic
{
     public abstract class Vehicle
     {
          protected Owner m_Owner;
          protected string m_Model;
          protected string m_LicenceNumber;
          protected Tank m_Tank;

          // $G$ DSN-999 (-3) This List should be readonly.
        protected Wheel[] m_Wheels;

          public string LicenceNumber
          {
               get
               {
                    return m_LicenceNumber;
               }
          }

          public Tank Tank
          {
               get
               {
                    return m_Tank;
               }
          }

          public Vehicle(Owner i_Owner, string i_Model, string i_LicenceNumber, Tank i_Tank, Wheel[] i_Wheels)
          {
               m_Owner = i_Owner;
               m_Model = i_Model;
               m_LicenceNumber = i_LicenceNumber;
               m_Tank = i_Tank;
               m_Wheels = i_Wheels;
          }

          public void ChangeAllWheelsAirPressureToMaximum()
          {
               foreach (Wheel wheel in m_Wheels) 
               {
                    wheel.LoadAirPressureToMaximum();
               }
          }

          public override string ToString()
          {
               string vehicleString;

               vehicleString = "\nModel: " + m_Model + "\nLicence number: " + m_LicenceNumber + "\nOwner: " + m_Owner.ToString() + "\nTank: "
                    + m_Tank.ToString() + "\nWheels information: \nNumber of wheels: " + m_Wheels.Length.ToString() + m_Wheels[0].ToString();

               return vehicleString;
          }
     }
}
