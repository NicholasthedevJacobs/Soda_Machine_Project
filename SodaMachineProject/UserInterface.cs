﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachineProject
{
    static class UserInterface
    {

        //Member Methods

        public static string SelectChange()
        {
            string coinToUse = "";       
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
        public static int SelectSodaToBuy()
        {
            Console.WriteLine("Which soda would you like to purchase?");
            Console.WriteLine("Press '1' for Cola.  Press '2' for Root Beer.  Press '3' for Orange Soda.");
            int sodaSelected = int.Parse(Console.ReadLine());
            if (sodaSelected <= 0 || sodaSelected > 3)
            {
                Console.WriteLine("Please select a valid option.");
                SelectSodaToBuy();
            }
            return sodaSelected;
        }
    }
}
