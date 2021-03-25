namespace Ex03.GarageLogic
{
     public abstract class Tank
     {
          protected float m_CurrentAmount;
          protected float m_MaximalAmount;
          protected float m_PrecentageOfCurrentAmout;

          public float MaximalAmount
          {
               get
               {
                    return m_MaximalAmount;
               }
          }

          public float CurrentAmount
          {
               get  
               {
                    return m_CurrentAmount;
               }
          }

          public Tank(float i_CurrentAmount, float i_MaximalAmount)
          {
               m_CurrentAmount = i_CurrentAmount;
               m_MaximalAmount = i_MaximalAmount;
               m_PrecentageOfCurrentAmout = (m_CurrentAmount / m_MaximalAmount) * 100;
          }

          protected void LoadTank(float i_AmountToLoad)
          {
               if (m_CurrentAmount + i_AmountToLoad <= m_MaximalAmount && i_AmountToLoad >= 0) 
               {
                    m_CurrentAmount += i_AmountToLoad;
                    m_PrecentageOfCurrentAmout = (m_CurrentAmount / m_MaximalAmount) * 100;
               }
               else
               {
                    throw new ValueOutOfRangeException(null, 0, m_MaximalAmount - m_CurrentAmount);
               }
          }

          public override string ToString()
          {
               string tankString;

               tankString = string.Format("\nCurrent amount: {0}\nMaximal amount: {1}\nPrecentage of current amount: {2}%", m_CurrentAmount, m_MaximalAmount, m_PrecentageOfCurrentAmout);

               return tankString;
          }
     }
}