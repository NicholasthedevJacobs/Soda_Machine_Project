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
        public Simulation()
        {
            customer = new Customer();
            sodaMachine = new SodaMachine();
        }

        //Member Methods
        public double CheckHowMuchMoneyEntered(string coinEntered)
        {
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
        public double ComparePaidCost(string userChoiceSoda, double valueOfCoin)
        {
            for (int i = 0; i < sodaMachine.inventory.Count; i++)
            {
                if (userChoiceSoda == sodaMachine.inventory[i].name)
                {
                    double priceOfSoda = sodaMachine.inventory[i].Cost;
                    double amountLeftToPay = priceOfSoda - valueOfCoin;

                    return amountLeftToPay;
                }
                else
                {
                   
                }
            }
            return 0;

        }
        
        public void MasterMethod()
        {
            string selectedSoda = UserInterface.SelectSodaToBuy();
            UserInterface.DisplaySodaCost(selectedSoda);
            UserInterface.InsertMoneyPrompt();
            string changeSelected = UserInterface.SelectChange();
            double valueOfCoin = CheckHowMuchMoneyEntered(changeSelected);
            double amountLeftToPay = ComparePaidCost(selectedSoda, valueOfCoin);
            Coin payment = customer.RemoveChange(changeSelected);
            sodaMachine.AddChangePayment(payment);
            while (amountLeftToPay > 0)
            {
                UserInterface.DisplayOutstandingPayment(amountLeftToPay);
            }
            //Coin payment = customer.RemoveChange(changeSelected);
            //sodaMachine.AddChangePayment(payment);
            
        }

    }
}
