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

            if (register.Count < 100)
            {
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
                    Nickel nickel = new Nickel();
                    register.Add(nickel);
                }
                while (register.Count >= 50 && register.Count < 100)
                {
                    Penny penny = new Penny();
                    register.Add(penny);
                }
            }
            if (inventory.Count < 50)
            {
                while (inventory.Count < 15)
                {
                    Cola cola = new Cola();
                    inventory.Add(cola);
                }
                while (inventory.Count >= 15 && inventory.Count < 30)
                {
                    OrangeSoda orangeSoda = new OrangeSoda();
                    inventory.Add(orangeSoda);
                }
                while (inventory.Count >= 30 && inventory.Count < 50)
                {
                    RootBeer rootBeer = new RootBeer();
                    inventory.Add(rootBeer);
                }
            }                    
        }


        //public void RemoveCanSoda(string userChoiceSoda)
        //{

        //   string userChoice = UserInterface.SelectSodaToBuy();
        //}

    }
}
