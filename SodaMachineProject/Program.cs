﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachineProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // SodaMachine user = new SodaMachine();

            //UserInterface.SelectChange();

            SodaMachine user = new SodaMachine();
            string blah = UserInterface.SelectSodaToBuy();
            user.RemoveCanSoda(blah);


            
        }
    }
}
