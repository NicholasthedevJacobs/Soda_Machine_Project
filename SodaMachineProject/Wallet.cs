using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachineProject
{
    class Wallet
    {
        //Member Variables

        public List<Coin> coins;
        public Card card;

        //Properties
        
        //Constructor
        public Wallet(Quarter quarter, Dime dime, Nickel nickel, Penny penny)
        {
            coins = new List<Coin>();
            card = new Card();

            while (coins.Count < 12)
            {
                coins.Add(quarter);
            }
            while (coins.Count >= 12 && coins.Count < 22)
            {
                coins.Add(dime);
            }
            while (coins.Count >= 22 && coins.Count < 37)
            {
                coins.Add(nickel);
            }
            while (coins.Count < 62)
            {
                coins.Add(penny);
            }

        }
        //Member Methods
    }
}
