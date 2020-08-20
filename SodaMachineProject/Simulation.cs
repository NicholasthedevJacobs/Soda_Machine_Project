﻿using System;
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
        public double CheckIfNegative(double returnChange)
        {           
            double returnChangeAbsolute = Math.Abs(returnChange);
            return returnChangeAbsolute;          
        }
        public void RemoveChangeFromMachine(double returnChange)
        {
            while (returnChange > 0 && sodaMachine.register.Count > 0)
            {
                if (returnChange >= 0.25)
                {
                    for (int i = 0; i < sodaMachine.register.Count; i++)
                    {
                        if (sodaMachine.register[i].name == "Quarter")
                        {
                            Coin coinReturnToWallet = sodaMachine.register[i];
                            sodaMachine.register.RemoveAt(i);
                            ReturnChangeToWallet(coinReturnToWallet);
                            returnChange -= sodaMachine.register[i].Value;
                            break;
                        }
                        
                    }
                }
                if (returnChange >= 0.10)
                {
                    for (int i = 0; i < sodaMachine.register.Count; i++)
                    {
                        if (sodaMachine.register[i].name == "Dime")
                        {
                            Coin coinReturnToWallet = sodaMachine.register[i];
                            sodaMachine.register.RemoveAt(i);
                            ReturnChangeToWallet(coinReturnToWallet);
                            returnChange -= sodaMachine.register[i].Value;
                            break;
                        }
                    }
                }
                if (returnChange >= 0.05)
                {
                    for (int i = 0; i < sodaMachine.register.Count; i++)
                    {
                        if (sodaMachine.register[i].name == "Nickel")
                        {
                            Coin coinReturnToWallet = sodaMachine.register[i];
                            sodaMachine.register.RemoveAt(i);
                            ReturnChangeToWallet(coinReturnToWallet);
                            returnChange -= sodaMachine.register[i].Value;
                            break;
                        }
                    }
                }
                if (returnChange >= 0.01)
                {
                    for (int i = 0; i < sodaMachine.register.Count; i++)
                    {
                        if (sodaMachine.register[i].name == "Penny")
                        {
                            Coin coinReturnToWallet = sodaMachine.register[i];
                            sodaMachine.register.RemoveAt(i);
                            ReturnChangeToWallet(coinReturnToWallet);
                            returnChange -= sodaMachine.register[i].Value;
                            break;
                        }
                    }
                }
                break;
            }
        }
        public void ReturnChangeToWallet(Coin coinReturnToWallet)
        {
            customer.wallet.coins.Add(coinReturnToWallet);
        }
        public double FinishRemainingBalance(double amountLeftToPay, double valueOfCoin)
        {
            amountLeftToPay -= valueOfCoin;
            return amountLeftToPay;
        }
        public void DispenseSoda(string selectedSoda)
        {
            for (int i = 0; i < sodaMachine.inventory.Count; i++)
            {
                if(sodaMachine.inventory[i].name == selectedSoda)
                {
                    Can canToAddToBackpack = sodaMachine.inventory[i];
                    sodaMachine.inventory.RemoveAt(i);
                    AddSodaToBackpack(canToAddToBackpack);
                    break;
                }
                else
                {
                    //GiveFullPaymentBack(remainingBalance, selectedSoda);
                }
            }
        }
        public double GiveFullPaymentBack(double remainingBalance, string selectedSoda)
        {
            for (int i = 0; i < sodaMachine.inventory.Count; i++)
            {
                if (selectedSoda == sodaMachine.inventory[i].name)
                {
                    double returnPrice = sodaMachine.inventory[i].Cost;
                    double fullPaymentBack = remainingBalance + returnPrice;
                    return fullPaymentBack;
                }                
            }
            return 0;

        }
        public bool CheckIfSodaStocked(string selectedSoda)
        {
            bool hasSoda = false;
            for(int i = 0; i < sodaMachine.inventory.Count; i++)
            {
                if(selectedSoda == sodaMachine.inventory[i].name)
                {
                    hasSoda = true;
                    return hasSoda;
                }
                else
                {
                    hasSoda = false;
                    UserInterface.DoesNotHaveSodaMessage(selectedSoda);                  
                }
            }
            return hasSoda;
        }
        public void AddSodaToBackpack(Can canToAddToBackpack)
        {
            customer.backpack.cans.Add(canToAddToBackpack);
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
                UserInterface.AskToContinueTransaction();
                string continueTransaction = UserInterface.TakeUserInputForContinue();
                if (continueTransaction == "1")
                {
                    changeSelected = UserInterface.SelectChange();
                    valueOfCoin = CheckHowMuchMoneyEntered(changeSelected);
                    double remainingBalance = FinishRemainingBalance(amountLeftToPay, valueOfCoin);                   
                    if (remainingBalance < 0)
                    {
                        bool hasSoda = CheckIfSodaStocked(selectedSoda);
                        if(hasSoda == true)
                        {
                            DispenseSoda(selectedSoda);
                            double returnChange = CheckIfNegative(remainingBalance);
                            RemoveChangeFromMachine(returnChange);
                        }
                        else
                        {
                            GiveFullPaymentBack(remainingBalance, selectedSoda);
                        }
                    }
                    else
                    {

                    }

                }
                else
                {

                }
            }
            //Coin payment = customer.RemoveChange(changeSelected);
            //sodaMachine.AddChangePayment(payment);
            
        }

    }
}
