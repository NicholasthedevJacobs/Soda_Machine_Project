using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachineProject
{
    class Simulation
    {
        //Member Variables
        public SodaMachine sodaMachine;
        public Customer customer;
        List<Coin> simulatedCoin;

        //Properties

        //Constructor
        public Simulation()
        {
            simulatedCoin = new List<Coin>();
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
            //List<Coin> simulatedCoin = new List<Coin>();

            while (returnChange > 0.001 && sodaMachine.register.Count > 0)
            {
                while (returnChange >= 0.25)
                {
                    for (int i = 0; i < sodaMachine.register.Count; i++)
                    {
                        if (sodaMachine.register[i].name == "Quarter")
                        {
                            Coin coinReturnToWallet = sodaMachine.register[i];
                            string coinName = sodaMachine.register[i].name;
                            sodaMachine.register.RemoveAt(i);
                            simulatedCoin.Add(coinReturnToWallet);
                            
                            //ReturnChangeToWallet(coinReturnToWallet);
                            returnChange -= sodaMachine.register[i].Value;
                            
                        }
                    }
                }
                while (returnChange >= 0.10)
                {
                    for (int i = 0; i < sodaMachine.register.Count; i++)
                    {
                        if (sodaMachine.register[i].name == "Dime" && returnChange >= 0.10)
                        {
                            Coin coinReturnToWallet = sodaMachine.register[i];
                            string coinName = sodaMachine.register[i].name;
                            sodaMachine.register.RemoveAt(i);

                            simulatedCoin.Add(coinReturnToWallet);
                            
                            returnChange -= sodaMachine.register[i].Value;
                            //SimulatedReturnChangeToWallet(coinReturnToWallet);  

                           
                        }
                    }
                    
                }
                
                while (returnChange >= 0.05)
                {
                    for (int i = 0; i < sodaMachine.register.Count; i++)
                    {
                        if (sodaMachine.register[i].name == "Nickel" && returnChange >= 0.05)
                        {
                            Coin coinReturnToWallet = sodaMachine.register[i];
                            string coinName = sodaMachine.register[i].name;
                            sodaMachine.register.RemoveAt(i);
                            simulatedCoin.Add(coinReturnToWallet);
                            
                            //ReturnChangeToWallet(coinReturnToWallet);
                            returnChange -= sodaMachine.register[i].Value;
                            
                        }
                    }
                }
                while (returnChange > 0.001)
                {
                    for (int i = 0; i < sodaMachine.register.Count; i++)
                    {
                        if (sodaMachine.register[i].name == "Penny" && returnChange >= 0.001)
                        {
                            Coin coinReturnToWallet = sodaMachine.register[i];
                            string coinName = sodaMachine.register[i].name;
                            sodaMachine.register.RemoveAt(i);
                            simulatedCoin.Add(coinReturnToWallet);
                            
                            //ReturnChangeToWallet(coinReturnToWallet);
                            returnChange -= sodaMachine.register[i].Value;
                        }                       
                 
                    }
                    
                }
                
            }           
        }
        public void ReturnChangeToWallet(Coin coinReturnToWallet)
        {
            customer.wallet.coins.Add(coinReturnToWallet);
        }
        public void ReturnChangeToMachine(Coin coinReturnToMachine)
        {
            sodaMachine.register.Add(coinReturnToMachine);
        }
        public void SimulatePaymentTotal(Coin payment)
        {
            simulatedCoin.Add(payment);
        }
        public void MoveCoinFromSimulatedToMachine()
        {
            while (simulatedCoin.Count > 0)
            {
                for (int i = 0; i < simulatedCoin.Count; i++)
                {
                    Coin coinReturnToMachine = simulatedCoin[i];
                    simulatedCoin.RemoveAt(i);
                    ReturnChangeToMachine(coinReturnToMachine);
                }
            }
        }
        public bool SimulatedCompareToActual(double returnChange)
        {
            double totalValue = 0;
            bool willDispense = false;

            for (int i = 0; i < simulatedCoin.Count; i++)
            {
                totalValue += simulatedCoin[i].Value;
            }
            if (totalValue < returnChange)
            {
                while (simulatedCoin.Count > 0)
                {
                    for (int i = 0; i < simulatedCoin.Count; i++)
                    {
                        Coin coinReturnToMachine = simulatedCoin[i]; ;
                        simulatedCoin.RemoveAt(i);
                        ReturnChangeToMachine(coinReturnToMachine);
                        willDispense = false;

                    }
                }
            }
            else
            {
                while (simulatedCoin.Count > 0)
                {
                    for (int i = 0; i < simulatedCoin.Count; i++)
                    {
                        Coin coinReturnToWallet = simulatedCoin[i]; ;
                        string nameOfCoin = simulatedCoin[i].name;
                        simulatedCoin.RemoveAt(i);
                        ReturnChangeToWallet(coinReturnToWallet);
                        UserInterface.ChangeReturnMessage(nameOfCoin);
                        willDispense = true;

                    }
                }

            }
            return willDispense;
        }
        public void ReturnChangeToUserWhenShort()
        {
            for (int i = 0; i < simulatedCoin.Count; i++)
            {
                Coin coinReturnToCustomer = simulatedCoin[i];
                string coinName = simulatedCoin[i].name;
                simulatedCoin.RemoveAt(i);
                UserInterface.ChangeReturnMessage(coinName);
                ReturnChangeToWallet(coinReturnToCustomer);

            }
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
                if (sodaMachine.inventory[i].name == selectedSoda)
                {
                    Can canToAddToBackpack = sodaMachine.inventory[i];
                    sodaMachine.inventory.RemoveAt(i);
                    AddSodaToBackpack(canToAddToBackpack);
                    UserInterface.DispenseSodaMessage(selectedSoda);
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
            for (int i = 0; i < sodaMachine.inventory.Count; i++)
            {
                if (selectedSoda == sodaMachine.inventory[i].name)
                {
                    hasSoda = true;
                    return hasSoda;
                }
                else
                {
                    //hasSoda = false;
                    //UserInterface.DoesNotHaveSodaMessage(selectedSoda);                  
                }
            }
            return hasSoda;
        }
        public void AddSodaToBackpack(Can canToAddToBackpack)
        {
            customer.backpack.cans.Add(canToAddToBackpack);
        }
        public bool CheckIfPaid(double amountLeftToPay)
        {
            bool hasPaid = false;
            if (amountLeftToPay < 0)
            {
                hasPaid = true;

            }
            return hasPaid;
        }
        public void MasterMethod()
        {
            bool hasSoda = false;
            bool hasPaid = false;
            string selectedSoda = UserInterface.SelectSodaToBuy();
            UserInterface.DisplaySodaCost(selectedSoda);
            //UserInterface.InsertMoneyPrompt();//Not super necessary
            string changeSelected = UserInterface.SelectChange();
            double valueOfCoin = CheckHowMuchMoneyEntered(changeSelected);
            double amountLeftToPay = ComparePaidCost(selectedSoda, valueOfCoin);
            hasPaid = CheckIfPaid(amountLeftToPay);
            while (hasPaid == true)
            {
                hasSoda = CheckIfSodaStocked(selectedSoda);
                if (hasSoda == true)
                {
                    double returnChange = CheckIfNegative(amountLeftToPay);
                    //possibly check if returnChange > 0
                    RemoveChangeFromMachine(returnChange);
                    bool willDispense = SimulatedCompareToActual(returnChange);
                    MoveCoinFromSimulatedToMachine();
                    if (willDispense == true)
                    {
                        DispenseSoda(selectedSoda);
                        hasPaid = true;
                    }
                    else
                    {
                        GiveFullPaymentBack(amountLeftToPay, selectedSoda);
                    }
                }
                while (hasPaid == false)
                {
                    amountLeftToPay = ComparePaidCost(selectedSoda, valueOfCoin);
                    Coin payment = customer.RemoveChange(changeSelected);
                    SimulatePaymentTotal(payment);

                    if (amountLeftToPay <= 0)
                    {
                        hasSoda = CheckIfSodaStocked(selectedSoda);
                        if (hasSoda == true)
                        {
                            double returnChange = CheckIfNegative(amountLeftToPay);
                            //possibly check if returnChange > 0
                            RemoveChangeFromMachine(returnChange);
                            bool willDispense = SimulatedCompareToActual(returnChange);
                            MoveCoinFromSimulatedToMachine();
                            if (willDispense == true)
                            {
                                DispenseSoda(selectedSoda);
                                hasPaid = true;
                            }
                            else
                            {
                                GiveFullPaymentBack(amountLeftToPay, selectedSoda);
                            }
                        }
                        else
                        {
                            GiveFullPaymentBack(amountLeftToPay, selectedSoda);
                        }
                    }
                    else
                    {
                        UserInterface.DisplayOutstandingPayment(amountLeftToPay);
                        bool hasMoney = UserInterface.AskIfHaveMoreMoneyToAdd();
                        if (hasMoney == true)
                        {
                            string continueTransaction = UserInterface.TakeUserInputForContinue();
                            if (continueTransaction == "1")
                            {

                                changeSelected = UserInterface.SelectChange();
                                valueOfCoin = CheckHowMuchMoneyEntered(changeSelected);
                                payment = customer.RemoveChange(changeSelected);
                                SimulatePaymentTotal(payment);
                                amountLeftToPay = FinishRemainingBalance(amountLeftToPay, valueOfCoin);


                                //Added lines here
                                double returnChange = CheckIfNegative(amountLeftToPay);
                                //possibly check if returnChange > 0
                                MoveCoinFromSimulatedToMachine();
                                RemoveChangeFromMachine(returnChange);
                                //MoveCoinFromSimulatedToWallet();
                                bool willDispense = SimulatedCompareToActual(returnChange);
                                //MoveCoinFromSimulatedToMachine();
                                if (willDispense == true)
                                {
                                    DispenseSoda(selectedSoda);
                                    hasPaid = true;
                                }
                                else
                                {
                                    GiveFullPaymentBack(amountLeftToPay, selectedSoda);
                                }
                            }
                            else
                            {
                                GiveFullPaymentBack(amountLeftToPay, selectedSoda);
                            }
                        }
                    }
                    break;

                }
                break;

            }
            
        }
    }
}