﻿using System;
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
        public Customer()
        {
            wallet = new Wallet();
            backpack = new Backpack(); 
        }

        //Member Methods
        public Coin RemoveChange(string changeSelected)
        {
            //Removes money from the wallet
            for (int i = 0; i < wallet.coins.Count; i++)
            {
                if (changeSelected == wallet.coins[i].name)
                {
                    Coin coinToRemove = wallet.coins[i];
                    wallet.coins.RemoveAt(i);
                    return coinToRemove;
                }
                else
                {
                    i++;
                }
            }return null;
        }
    }
}
