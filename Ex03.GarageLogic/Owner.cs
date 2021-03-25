﻿namespace Ex03.GarageLogic
{
     public class Owner
     {
          private string m_Name;
          private string m_PhoneNumber;

          public string Name
          {
               get
               {
                    return m_Name;
               }
          }

          public string PhoneNumber
          {
               get
               {
                    return m_PhoneNumber;
               }
          }

          public Owner(string i_Name, string i_PhoneNumber)
          {
               m_Name = i_Name;
               m_PhoneNumber = i_PhoneNumber;
          }

          public override string ToString()
          {
               string ownerString;

               ownerString = "\nName: " + m_Name + "\nPhone number: " + m_PhoneNumber;

               return ownerString;
          }
     }
}