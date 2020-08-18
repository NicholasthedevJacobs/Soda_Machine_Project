using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachineProject
{
    class SodaMachine
    {
        //Member Variables

        public List<Coin> register;
        public List<Can> inventory;

        //Properties

        //Constructor
        public SodaMachine()
        {
            register = new List<Coin>();
            inventory = new List<Can>();

            while (register.Count < 20)
            {
                Quarter quarter = new Quarter();
                register.Add(quarter);
            }
            while (register.Count >= 20 && register.Count < 30)
            {
                Dime dime = new Dime();
                register.Add(dime);
            }
            while (register.Count >= 30 && register.Count < 50)
            {
                Nickle nickle = new Nickle();
                register.Add(nickle);
            }
            while (register.Count >= 50 && register.Count < 100)
            {
                Penny penny = new Penny();
                register.Add(penny);
            }




        }

        //Member Variables
    }
}
