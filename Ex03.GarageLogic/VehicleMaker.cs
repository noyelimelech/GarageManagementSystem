namespace Ex03.GarageLogic
{
     public static class VehicleMaker
     {
          public static Vehicle TruckMaker(Owner i_Owner, string i_Model, string i_LicenceNumber, GasTank i_GasTank, Wheel[] i_Wheels, bool i_IsThereDangerousMatirial, float i_BaggaeVolume)
          {
               return new Truck(i_Owner, i_Model, i_LicenceNumber, i_GasTank, i_Wheels, i_IsThereDangerousMatirial, i_BaggaeVolume);
          }

          public static Vehicle GasBikeMaker(Owner i_Owner, string i_Model, string i_LicenceNumber, GasTank i_GasTank, Wheel[] i_Wheels, Bike.eLicenceType i_LicenceType, int i_EngineVolume)
          {
               return new GasBike(i_Owner, i_Model, i_LicenceNumber, i_GasTank, i_Wheels, i_LicenceType, i_EngineVolume);
          }

          public static Vehicle ElectronicBikeMaker(Owner i_Owner, string i_Model, string i_LicenceNumber, ElectronicTank i_ElectronicTank, Wheel[] i_Wheels, Bike.eLicenceType i_LicenceType, int i_EngineVolume)
          {
               return new ElectronicBike(i_Owner, i_Model, i_LicenceNumber, i_ElectronicTank, i_Wheels, i_LicenceType, i_EngineVolume);
          }

          public static Vehicle GasCarMaker(Owner i_Owner, string i_Model, string i_LicenceNumber, GasTank i_GasTank, Wheel[] i_Wheels, Car.eColor i_Color, Car.eNumberOfDoors i_NumberOfDoors)
          {
               return new GasCar(i_Owner, i_Model, i_LicenceNumber, i_GasTank, i_Wheels, i_Color, i_NumberOfDoors);
          }

          public static Vehicle ElectronicCarMaker(Owner i_Owner, string i_Model, string i_LicenceNumber, ElectronicTank i_ElectronicTank, Wheel[] i_Wheels, Car.eColor i_Color, Car.eNumberOfDoors i_NumberOfDoors)
          {
               return new ElectronicCar(i_Owner, i_Model, i_LicenceNumber, i_ElectronicTank, i_Wheels, i_Color, i_NumberOfDoors);
          }
     }
}
