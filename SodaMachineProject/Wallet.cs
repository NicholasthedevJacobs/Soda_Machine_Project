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
        public Wallet()
        {
            coins = new List<Coin>();
            card = new Card();

            if (coins.Count < 62)
            {
                while (coins.Count < 12)
                {
                    coins.Add(new Quarter());
                }
                while (coins.Count >= 12 && coins.Count < 22)
                {
                    coins.Add(new Dime());
                }
                while (coins.Count >= 22 && coins.Count < 37)
                {
                    coins.Add(new Nickel());
                }
                while (coins.Count < 62)
                {
                    coins.Add(new Penny());
                }
            }           
        }
        //Member Methods
    }
}
