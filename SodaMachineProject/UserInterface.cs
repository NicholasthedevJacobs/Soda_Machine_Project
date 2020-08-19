﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachineProject
{
    public static class UserInterface
    {

        //Member Methods

        public static string SelectChange()
        {
            string coinToUse = "";
            //DisplaySodaCost();
            bool isValid = false;
            while (isValid != true)
            {
                Console.WriteLine("What coin would you like to put in the machine?");
                Console.WriteLine("Press '1' for Quarter.  Press '2' for Dime.  Press '3' for Nickel.  Press '4' for Penny. ");
                coinToUse = Console.ReadLine();
                switch (coinToUse)
                 {
                    case "1":
                        coinToUse = "Quarter";
                        isValid = true;
                        break;
                    case "2":
                        coinToUse = "Dime";
                        isValid = true;
                        break;
                    case "3":
                        coinToUse = "Nickel";
                        isValid = true;
                        break;
                    case "4":
                        coinToUse = "Penny";
                        isValid = true;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option.");
                        break;
                 }
            }return coinToUse;
        }
        public static string SelectSodaToBuy()
        {
            string sodaSelected = "";
            bool isValid = false;
            while (isValid != true)
            {
                Console.WriteLine("Which soda would you like to purchase?");
                Console.WriteLine("Press '1' for Cola.  Press '2' for Root Beer.  Press '3' for Orange Soda.");
                sodaSelected = Console.ReadLine();
                switch (sodaSelected)
                {
                    case "1":
                        sodaSelected = "Cola";
                        Console.WriteLine("You chose Cola");
                        isValid = true;
                        break;
                    case "2":
                        sodaSelected = "Root Beer";
                        Console.WriteLine("You chose Root Beer");
                        isValid = true;
                        break;
                    case "3":
                        sodaSelected = "Orange Soda";
                        Console.WriteLine("You chose Orange Soda");
                        isValid = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection.  Please choose again.");
                        break;
                }
            }return sodaSelected;

        }
        public static void DisplaySodaCost(string sodaChosen)
        {
            //string sodaChosen = SelectSodaToBuy();
            if (sodaChosen == "Cola")
            {
                Console.WriteLine("Cola costs $0.35");
            }
            else if (sodaChosen == "Root Beer")
            {
                Console.WriteLine("Root Beer costs $0.60");
            }
            else if (sodaChosen == "Orange Soda")
            {
                Console.WriteLine("Orange Soda costs $0.06");
            }
        }
        public static void HowMuchLeftToPayMessage(double leftToPay)
        {
            Console.WriteLine($"You still owe ${leftToPay}.");
        }
        public static void InsertMoneyPrompt()
        {
            Console.WriteLine("Please enter a coin");
        }
        //public static void 

    }
}
