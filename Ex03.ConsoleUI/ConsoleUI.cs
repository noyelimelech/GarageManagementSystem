using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
     public static class ConsoleUI
     {
          public enum eMenuOption
          {
               None,
               NewVehicleToGarage,
               ShowLicenceNumbers,
               ChangeStatus,
               ChangeWheelsAirPressureToMax,
               PutGas,
               ChargeElectric,
               ShowFullDetail,
               Exit
          }

          private static Garage s_Garage = new Garage();

          public static eMenuOption ShowMenuAndGetFromUserChoice()
          {
               eMenuOption choice = eMenuOption.None;

               Console.WriteLine("1. Enter new car to the garage");
               Console.WriteLine("2. Show licence number of garage vehicle");
               Console.WriteLine("3. Change status of garage vehicle");
               Console.WriteLine("4. Change wheels air pressure to maximum");
               Console.WriteLine("5. Put gas in gas vehicle");
               Console.WriteLine("6. Charge electric vehicle");
               Console.WriteLine("7. Show full details of garage vehicle");
               Console.WriteLine("8. EXIT\n\n");
               
               choice = (eMenuOption)getFromUerNumberInARange(1,8);

               return choice;
          }

          public static void OperateUserChoice(eMenuOption i_choice)
          {
               string licenceNumber = null;

               if ((i_choice != eMenuOption.ShowLicenceNumbers) && (i_choice != eMenuOption.NewVehicleToGarage))
               {
                    licenceNumber = getFromUserLicenceNumberOfVehicleExist();
               }
               switch (i_choice)
               {
                    case eMenuOption.NewVehicleToGarage:
                         getFromUserNewVehicleInfoAndInsertVehicleToGarageOrChangeStatusIfInGarage();
                         break;
                    case eMenuOption.ShowLicenceNumbers:
                         showGarageVehiclesLicenceNumbers();
                         break;
                    case eMenuOption.ChangeStatus:
                         getFromUserNewGarageVehicleStatusAndChange(licenceNumber);
                         break;
                    case eMenuOption.ChangeWheelsAirPressureToMax:
                         changeWheelsAirPressureToMaximum(licenceNumber);
                         break;
                    case eMenuOption.PutGas:
                         getFromUserAmountOfGasAndputGasOnVehicle(licenceNumber);
                         break;
                    case eMenuOption.ChargeElectric:
                         getFromUserAmountOfMinutesAndChargeElectronicVehicle(licenceNumber);
                         break;
                    case eMenuOption.ShowFullDetail:
                         showFullDetailsOfVehicle(licenceNumber);
                         break;
               }

               Console.WriteLine("\n\nPress any key to get back to main menu");
               Console.ReadLine();
               Console.Clear();
          }

          private static void getFromUserAmountOfMinutesAndChargeElectronicVehicle(string i_LicenceNumber)
          {
               float amountToLoadInHours;
               bool isCurrectInput = false;
               VehicleCardInGarage vehicleCard;
               ElectronicTank vehicleElectornicTank;

               vehicleCard = s_Garage.GetVehicleCardByLicenceNumber(i_LicenceNumber);
               vehicleElectornicTank = vehicleCard.Vehicle.Tank as ElectronicTank;
               if (vehicleElectornicTank != null)
               {
                    Console.WriteLine("Please enter amount of time (in minutes) you want to add");
                    while (!isCurrectInput)
                    {
                         try
                         {
                              amountToLoadInHours = getFromUserMinutesAndReturnInHoursFloat();
                              vehicleElectornicTank.LoadElectronicTank(amountToLoadInHours);
                              isCurrectInput = true;
                         }
                         catch (ValueOutOfRangeException ex)
                         {
                              Console.WriteLine("You must enter a number from {0} to {1}. Please try again!", (int)(ex.MinValue * 60), (int)(ex.MaxValue * 60));
                         }
                    }

                    Console.WriteLine("Electronic tank has been charged succusfully!");
               }
               else
               {
                    Console.WriteLine("This vehicle isnt electronic, no charge has been done!");
               }
          }

          private static float getFromUserMinutesAndReturnInHoursFloat()
          {
               int amountToLoadFromUserInMinutes;
               float amountToLoadInHours = 0f;
               bool isCurrectInput = false;

               while (!isCurrectInput)
               {
                    try
                    {
                         amountToLoadFromUserInMinutes = int.Parse(Console.ReadLine());
                         amountToLoadInHours = (float)(amountToLoadFromUserInMinutes / 60) + ((float)(amountToLoadFromUserInMinutes % 60) / 60);
                         isCurrectInput = true;
                    }
                    catch (FormatException)
                    {
                         Console.WriteLine("You must enter a integer number. Please try again!");
                    }
               }

               return amountToLoadInHours;
          }

          private static void getFromUserAmountOfGasAndputGasOnVehicle(string i_LicenceNumber)
          {
               GasTank.eGasType gasType;
               float amountToLoad = 0;
               bool isCurrectAmount = false;
               bool isCurrectGasType = false;
               VehicleCardInGarage vehicleCard;
               GasTank vehicleGasTank;

               vehicleCard = s_Garage.GetVehicleCardByLicenceNumber(i_LicenceNumber);
               vehicleGasTank = vehicleCard.Vehicle.Tank as GasTank;
               if (vehicleGasTank != null)
               {
                    gasType = vehicleGasTank.GasType;
                    while (!isCurrectGasType || !isCurrectAmount) 
                    {
                         try
                         {
                              if (!isCurrectAmount)
                              {
                                   Console.WriteLine("What is the amount of gas you want to add?");
                                   amountToLoad = float.Parse(Console.ReadLine());
                                   isCurrectAmount = (amountToLoad <= vehicleGasTank.MaximalAmount - vehicleGasTank.CurrentAmount) && (amountToLoad >= 0);
                              }
                              if (!isCurrectGasType && isCurrectAmount)
                              {
                                   gasType = getFromUserGasType();
                                   isCurrectGasType = true;
                              }

                             vehicleGasTank.LoadGasTank(amountToLoad, gasType);
                         }
                         catch (FormatException)
                         {
                              Console.WriteLine("You must enter a float number. Please try again!");

                         }
                         catch (ValueOutOfRangeException ex)
                         {
                              Console.WriteLine(ex.Message + ". Please try again!");
                              isCurrectAmount = false;
                         }
                         catch (ArgumentException argumentEx)
                         {
                              Console.WriteLine(argumentEx.Message + ". Please try again!");
                              isCurrectGasType = false;
                         }
                    }

                    Console.WriteLine("Gas has been added succusfully!");
               }
               else
               {
                    Console.WriteLine("This vehicle isnt on gas, gas was not added!");
               }
          }

          private static GasTank.eGasType getFromUserGasType()
          {
               int userChoiceGasType;
               GasTank.eGasType gasType = GasTank.eGasType.None;

               Console.WriteLine("Please enter you wanted gas type from the following list:\n1.{0}\n2.{1}\n3.{2}\n4.{3}",GasTank.eGasType.Soler.ToString(),
                    GasTank.eGasType.Octan95.ToString(), GasTank.eGasType.Octan96.ToString(), GasTank.eGasType.Octan98.ToString());
               userChoiceGasType = getFromUerNumberInARange(1, 4);
               gasType = (GasTank.eGasType)userChoiceGasType;

               return gasType;
          }

          private static string getFromUserLicenceNumberOfVehicleExist()
          {
               bool isVehicleExist = false;
               string licenceNumber = null;

               while (!isVehicleExist)
               {
                    Console.WriteLine("Please enter a vehicle licence number");
                    licenceNumber = Console.ReadLine();
                    isVehicleExist = s_Garage.IsVehicleExistsInGarage(licenceNumber);
                    if(!isVehicleExist)
                    {
                         Console.WriteLine("This vehicle dosent exist in the garage. Please try again!");
                    }
               }

               return licenceNumber;
          }

          private static void changeWheelsAirPressureToMaximum(string i_LicenceNumber)
          {
               VehicleCardInGarage vehicleCard = s_Garage.GetVehicleCardByLicenceNumber(i_LicenceNumber);

               vehicleCard.Vehicle.ChangeAllWheelsAirPressureToMaximum();
               Console.WriteLine("Air pressure has changed to maximum");
          }

          private static void getFromUserNewGarageVehicleStatusAndChange(string i_LicenceNumber)
          {
               int userChoiceStatus;
               VehicleCardInGarage.eVehicleStatus vehicleStatus;

               Console.WriteLine("Please choose vehicle new status from the following list:\n1.In fixing proccess\n2.{0}\n3.{1}",
                    VehicleCardInGarage.eVehicleStatus.Fixed.ToString(), VehicleCardInGarage.eVehicleStatus.Payed.ToString());
               userChoiceStatus = getFromUerNumberInARange(1, 3);
               vehicleStatus = (VehicleCardInGarage.eVehicleStatus)userChoiceStatus;
               if (s_Garage.GetVehicleCardByLicenceNumber(i_LicenceNumber).VehicleStatus == vehicleStatus)
               {
                    Console.WriteLine("The vehicle is already in this status");
               }
               else
               {
                    s_Garage.GetVehicleCardByLicenceNumber(i_LicenceNumber).VehicleStatus = vehicleStatus;
                    Console.WriteLine("The status changed");
               }
          }

          private static void showGarageVehiclesLicenceNumbers()
          {
               int userChoice;
               VehicleCardInGarage.eVehicleStatus userVehicleStatus;
               List<string> arrLicenceNumberOnDemend;
               string allLicenceNumberOnDemend = string.Empty;

               Console.WriteLine("Choose which vehicles licence numbers you want from the following list:\n1.In fixing procces\n2.{0}\n3.{1}\n4.All the vehicles in garage",
                    VehicleCardInGarage.eVehicleStatus.Fixed.ToString(), VehicleCardInGarage.eVehicleStatus.Payed.ToString());
               userChoice = getFromUerNumberInARange(1, 4);
               if(userChoice != 4)
               {
                    userVehicleStatus = (VehicleCardInGarage.eVehicleStatus)userChoice;
                    arrLicenceNumberOnDemend = s_Garage.GetArrayOfLicenceNumberByStatus(userVehicleStatus);
                    if(userVehicleStatus != VehicleCardInGarage.eVehicleStatus.InFixingProccess)
                    {
                         Console.WriteLine("Licence numbers of vehicle with status '{0}': ", (VehicleCardInGarage.eVehicleStatus)(userChoice));
                    }
                    else
                    {
                         Console.WriteLine("Licence numbers of vehicle with status 'In fixing proccess':");
                    }
               }
               else
               {
                    arrLicenceNumberOnDemend = s_Garage.GetArrayOfAllLicenceNumber();
                    Console.WriteLine("Licence numbers of vehicle with all statuses :");
               }

               foreach(string licenceNumber in arrLicenceNumberOnDemend)
               {
                    allLicenceNumberOnDemend += licenceNumber + "\n";
               }

               if(arrLicenceNumberOnDemend.Count == 0)
               {
                    Console.WriteLine("There is no vehicle in this status.");
               }

               Console.Write(allLicenceNumberOnDemend);
          }


          private static void getFromUserNewVehicleInfoAndInsertVehicleToGarageOrChangeStatusIfInGarage()
          {
               string licenceNumber;

               Console.WriteLine("Please enter vehicle licence number");
               licenceNumber = getFromUserAnUnemptyString();
               if (s_Garage.IsVehicleExistsInGarage(licenceNumber))
               {
                    Console.WriteLine("The vehicle is already in the garage. His status changed to 'In fixing proccess'");
                    s_Garage.GetVehicleCardByLicenceNumber(licenceNumber).VehicleStatus = VehicleCardInGarage.eVehicleStatus.InFixingProccess;
               }
               else
               {
                    getFromUserNewVehicleInfoAndInsertVehicleToGarage(licenceNumber);
                    Console.WriteLine("Entering the new vehicle into the garage. WELCOME!");
               }
          }

          private static void getFromUserNewVehicleInfoAndInsertVehicleToGarage(string i_LicenceNumber)
          {
               int userChoice;
               Owner owner = getFromUserOwnerDetails();
               string model;
               VehicleCardInGarage newVehicleCard = null;

               Console.WriteLine("Please enter vehicle model:");
               model = getFromUserAnUnemptyString();
               Console.WriteLine("What kind of vehicle is it. Choose from the following list:\n1.Car\n2.Bike\n3.Truck");
               userChoice = getFromUerNumberInARange(1, 3);
               switch (userChoice)
               {
                    case 1:
                         newVehicleCard = getFromUserInfoAboutCarAndMakeAVehicleCard(owner, model, i_LicenceNumber);
                         break;
                    case 2:
                         newVehicleCard = getFromUserInfoAboutBikeAndMakeAVehicleCard(owner, model, i_LicenceNumber);
                         break;
                    case 3:
                         newVehicleCard = getFromUserInfoAboutTruckAndMakeAVehicleCard(owner, model, i_LicenceNumber);
                         break;
               }

               s_Garage.EnterVehicleToGarage(newVehicleCard, i_LicenceNumber);
          }

          private static VehicleCardInGarage getFromUserInfoAboutTruckAndMakeAVehicleCard(Owner i_Owner, string i_Model, string i_LicenceNumber)
          {
               int userChoice;
               float baggageVolume;
               bool isThereDangerousMetials;
               GasTank gasTank = getFromUserGasTankInfo(Truck.k_GasType, Truck.k_MaximalTankSize);
               Wheel[] wheels = getFromUserVehicleWheels(Truck.k_NumOfWheels, Truck.k_MaximalAirPressure);
               Vehicle vehicle;

               Console.WriteLine("What is the truck's baggage volume?");
               baggageVolume = getFromUserUnNegativeFloatLessThanMax(float.MaxValue);
               Console.WriteLine("Is there an dangerous metirials?\n1.YES\n2.NO");
               userChoice = getFromUerNumberInARange(1, 2);
               isThereDangerousMetials = userChoice == 1;
               vehicle = VehicleMaker.TruckMaker(i_Owner, i_Model, i_LicenceNumber, gasTank, wheels, isThereDangerousMetials, baggageVolume);

               return new VehicleCardInGarage(vehicle);
          }

          private static GasTank getFromUserGasTankInfo(GasTank.eGasType i_GasType, float i_MaximalTankSize)
          {
               float currentAmountOfGas;

               Console.WriteLine("What is the current amount of gas in vehicle?");
               currentAmountOfGas = getFromUserUnNegativeFloatLessThanMax(i_MaximalTankSize);

               return new GasTank(currentAmountOfGas, i_MaximalTankSize, i_GasType);
          }

          private static VehicleCardInGarage getFromUserInfoAboutBikeAndMakeAVehicleCard(Owner i_Owner, string i_Model, string i_LicenceNumber)
          {
               bool isCurrectInput = false;
               int userChoice;
               int engineVolume = 0;
               Bike.eLicenceType licenceType;
               GasTank gasTank;
               ElectronicTank electronicTank;
               Wheel[] wheels = getFromUserVehicleWheels(Bike.k_NumberOfWheels, Bike.k_MaximalAirPressure);
               Vehicle vehicle;

               Console.WriteLine("What is the bike's enginge volume?");
               while (!isCurrectInput)
               {
                    try
                    {
                         engineVolume = int.Parse(Console.ReadLine());
                         isCurrectInput = engineVolume > 0;
                         if (!isCurrectInput)
                         {
                              Console.WriteLine("The engine volume must be positive. Please try again!");
                         }
                    }
                    catch (FormatException)
                    {
                         Console.WriteLine("The volume must be an integer number. Please try again!");
                    }
               }

               Console.WriteLine("What type of licence is needed for this bike??\n1.A\n2.A1\n3.A2\n4.B");
               userChoice = getFromUerNumberInARange(1, 4);
               licenceType = (Bike.eLicenceType)userChoice;
               Console.WriteLine("Choose what type of bike is it from the following list:\n1.Gas bike\n2.Electronic bike");
               userChoice = getFromUerNumberInARange(1, 2);
               if (userChoice == 1)
               {
                    gasTank = getFromUserGasTankInfo(GasBike.k_GasType, GasBike.k_MaximalTankSize);
                    vehicle = VehicleMaker.GasBikeMaker(i_Owner, i_Model, i_LicenceNumber, gasTank, wheels, licenceType, engineVolume);
               }
               else
               {
                    electronicTank = getFromUserElectronicTankInfo(ElectronicBike.k_MaximalTankSize);
                    vehicle = VehicleMaker.ElectronicBikeMaker(i_Owner, i_Model, i_LicenceNumber, electronicTank, wheels, licenceType, engineVolume);
               }

               return new VehicleCardInGarage(vehicle);
          }

          private static ElectronicTank getFromUserElectronicTankInfo(float i_MaximalTankSize)
          {
               float currentAmount = 0;
               bool isCurrect = false;

               Console.WriteLine("What is the current amount of time (in minutes) in vehicle?");
               while(!isCurrect)
               {
                    currentAmount = getFromUserMinutesAndReturnInHoursFloat();
                    isCurrect = currentAmount <= i_MaximalTankSize && currentAmount >= 0;
                    if(!isCurrect)
                    {
                         Console.WriteLine("Wrong value, amount of time possible is betweeen 0 to {0}. Please try again!", (int)(i_MaximalTankSize * 60));
                    }
               }

               return new ElectronicTank(currentAmount, i_MaximalTankSize);
          }

          private static VehicleCardInGarage getFromUserInfoAboutCarAndMakeAVehicleCard(Owner i_Owner, string i_Model, string i_LicenceNumber)
          {
               int userChoice;
               Car.eNumberOfDoors numberOfDoors;
               Car.eColor carColor;
               GasTank gasTank;
               ElectronicTank electronicTank;
               Wheel[] wheels = getFromUserVehicleWheels(Car.k_NumberOfWheels, Car.k_MaximalAirPressure);
               Vehicle vehicle;

               Console.WriteLine("How many doors the car have? 2 or 3 or 4 or 5");
               userChoice = getFromUerNumberInARange(2, 5);
               numberOfDoors = (Car.eNumberOfDoors)(userChoice);
               Console.WriteLine("What is the car color?\n1.Red\n2.Blue\n3.Black\n4.Gray");
               userChoice = getFromUerNumberInARange(1, 4);
               carColor = (Car.eColor)(userChoice);
               Console.WriteLine("Choose what type of car is it from the following list:\n1.Gas car\n2.Electronic car");
               userChoice = getFromUerNumberInARange(1, 2);
               if (userChoice == 1)
               {
                    gasTank = getFromUserGasTankInfo(GasCar.k_GasType, GasCar.k_MaximalTankSize);
                    vehicle = VehicleMaker.GasCarMaker(i_Owner, i_Model, i_LicenceNumber, gasTank, wheels, carColor, numberOfDoors);
               }
               else
               {
                    electronicTank = getFromUserElectronicTankInfo(ElectronicCar.k_MaximalTankSize);
                    vehicle = VehicleMaker.ElectronicCarMaker(i_Owner, i_Model, i_LicenceNumber, electronicTank, wheels, carColor, numberOfDoors);
               }

               return new VehicleCardInGarage(vehicle);
          }

          private static Wheel[] getFromUserVehicleWheels(int i_NumOfWheels, float i_MaximalAirPressure)
          {
               Wheel[] wheels = new Wheel[i_NumOfWheels];
               string makerName;
               float currentAirPressure;

               Console.WriteLine("What is the wheels maker name?");
               makerName = getFromUserAnUnemptyString();
               Console.WriteLine("What is the curretn air pressure in the wheels");
               currentAirPressure = getFromUserUnNegativeFloatLessThanMax(i_MaximalAirPressure);
               for (int i = 0; i < wheels.Length; i++) 
               {
                    wheels[i] = new Wheel(makerName, currentAirPressure, i_MaximalAirPressure);
               }

               return wheels;
          }

          private static float getFromUserUnNegativeFloatLessThanMax(float i_MaximalValue)
          {
               bool isCurrectInput = false;
               float validFloatFromUser = 0;

               while (!isCurrectInput)
               {
                    try
                    {
                         validFloatFromUser = float.Parse(Console.ReadLine());
                         isCurrectInput = validFloatFromUser >= 0;
                         if (!isCurrectInput)
                         {
                              Console.WriteLine("Wrong value, cant be negative. Please try again!");
                         }
                         else
                         {
                              isCurrectInput = validFloatFromUser <= i_MaximalValue;
                              if (!isCurrectInput)
                              {
                                   Console.WriteLine("Wrong value, must be no more than {0}. Please try again!", i_MaximalValue);
                              }
                         }
                    }
                    catch (FormatException)
                    {
                         Console.WriteLine("Wrong value, must be an float number. Please try again!");
                    }
               }

               return validFloatFromUser;
          }

          private static string getFromUserAnUnemptyString()
          {
               bool isCurrectInput = false;
               string validStringFromUser = string.Empty;

               while (!isCurrectInput)
               {
                    validStringFromUser = Console.ReadLine();
                    isCurrectInput = validStringFromUser != string.Empty && !validStringFromUser.StartsWith(" ");
                    if (!isCurrectInput)
                    {
                         Console.WriteLine("Wrong input, must have at least one character. Please try again!");
                    }
               }

               return validStringFromUser;
          }

          private static Owner getFromUserOwnerDetails()
          {
               string ownerName;
               string ownerPhoneNumber;

               Console.WriteLine("Please enter owner name:");
               ownerName = getFromUserStringOnlyWithLetters();
               Console.WriteLine("Please enter owner phone number:");
               ownerPhoneNumber = getFromUserStringOnlyWithNumbers();

               return new Owner(ownerName, ownerPhoneNumber);
          }

          private static string getFromUserStringOnlyWithNumbers()
          {
               string validNumericalString = string.Empty;
               bool isCurrectInput = false;

               while(!isCurrectInput)
               {
                    validNumericalString = getFromUserAnUnemptyString();
                    isCurrectInput = true;
                    for (int i = 0; i < validNumericalString.Length; i++) 
                    {
                         if(!char.IsNumber(validNumericalString[i]))
                         {
                              isCurrectInput = false;
                         }
                    }
                    if (!isCurrectInput)
                    {
                         Console.WriteLine("Wrong input, must be only numbers. Please try again!");
                    }
               }

               return validNumericalString;
          }

          private static string getFromUserStringOnlyWithLetters()
          {
               string validEnglishLetterString = string.Empty;
               bool isCurrectInput = false;

               while (!isCurrectInput)
               {
                    validEnglishLetterString = getFromUserAnUnemptyString();
                    isCurrectInput = true;
                    for (int i = 0; i < validEnglishLetterString.Length; i++) 
                    {
                         if (!char.IsLetter(validEnglishLetterString[i]) && validEnglishLetterString[i] != ' ') 
                         {
                              isCurrectInput = false;
                         }
                    }
                    if(!isCurrectInput)
                    {
                         Console.WriteLine("Wrong input, must be only letters. Please try again!");
                    }
               }

               return validEnglishLetterString;
          }

          private static int getFromUerNumberInARange(int i_MinRange, int i_MaxRange)
          {
               bool isCurrectInput = false;
               int userChoice = -1;

               while (!isCurrectInput)
               {
                    try
                    {
                         userChoice = int.Parse(Console.ReadLine());
                         if (userChoice >= i_MinRange && userChoice <= i_MaxRange) 
                         {
                              isCurrectInput = true;
                         }
                         else
                         {
                              Console.WriteLine("You must choose an option from the list. Please try again!");
                         }
                    }
                    catch (FormatException)
                    {
                         Console.WriteLine("You must enter a integer value from the list. Please try again!");
                    }
               }
               return userChoice;
          }

          private static void showFullDetailsOfVehicle(string i_LicenceNumber)
          {
               Console.WriteLine(s_Garage.GetVehicleCardByLicenceNumber(i_LicenceNumber).ToString());
          }
     }
}



