namespace Ex03.ConsoleUI
{
    // $G$ RUL-004 (-20) Wrong zip name format / folder name format


    // $G$ CSS-999 (-5) Standards are not kept as required - you should use StyleCop.

    public class Program
     {
          public static void Main()
          {
               ConsoleUI.eMenuOption menuChoice = ConsoleUI.ShowMenuAndGetFromUserChoice();

               while (menuChoice != ConsoleUI.eMenuOption.Exit)
               {
                    ConsoleUI.OperateUserChoice(menuChoice);
                    menuChoice = ConsoleUI.ShowMenuAndGetFromUserChoice();
               }
          }
     }
}
