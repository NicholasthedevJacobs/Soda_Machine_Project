using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachineProject
{
    class Simulation
    {
        //Member Variables
        public SodaMachine sodaMachine;
        public Customer customer;

        //Properties

        //Constructor

        //Member Methods
        public double CheckHowMuchMoneyEntered()
        {
            //double valueOfCoin = 0.00;
            string coinEntered = UserInterface.SelectChange();

            for (int i = 0; i < customer.wallet.coins.Count; i++)
            {
                if (coinEntered == customer.wallet.coins[i].name)
                {
                    double valueOfCoin = customer.wallet.coins[i].Value;
                    return valueOfCoin;
                }
                else
                {
                    i++;
                }
            }
            return 0;
        }
    }
}
