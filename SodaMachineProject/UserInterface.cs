using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachineProject
{
    static class UserInterface
    {

        //Member Methods

        public void SelectChange()
        {
            Console.WriteLine("What coin would you like to put in the machine?");
            Console.WriteLine("Press '1' for Quarter.  Press '2' for Dime.  Press '3' for Nickel.  ");
        }
    }
}
