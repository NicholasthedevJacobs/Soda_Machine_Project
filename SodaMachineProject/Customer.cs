using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachineProject
{
    class Customer
    {
        //Member Variables

        public Wallet wallet;
        public Backpack backpack;

        //Properties

        //Constructor
        public Customer(Wallet wallet, Backpack backpack)
        {
            this.wallet = wallet;
            this.backpack = backpack;
        }

        //Member Methods
    }
}
