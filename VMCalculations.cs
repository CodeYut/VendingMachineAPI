using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachineAPI;
using VendingMachineAPI.Models;

namespace VendingMachineAPI
{
    class VMCalculations
    {
        static void DispenseItem(string[] args)
        {

            decimal Cost;
            decimal MoneyInserted;
            decimal Change;
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;
            int pennies = 0;


            Cost = Convert.ToDecimal(Console.ReadLine());

            MoneyInserted = Convert.ToDecimal(Console.ReadLine());

            Change = MoneyInserted - Cost;

            Console.WriteLine(Change);


            while (Change - Convert.ToDecimal(.25) >= 0)
            {
                Change -= Convert.ToDecimal(.25);
                quarters ++;
            }

            while (Change - Convert.ToDecimal(.10) >= 0)
            {
                Change -= Convert.ToDecimal(.10);
                dimes++;
            }

            while (Change - Convert.ToDecimal(.05) >= 0)
            {
                Change -= Convert.ToDecimal(.05);
                nickels++;
            }

            while (Change - Convert.ToDecimal(.01) >= 0)
            {
                Change -= Convert.ToDecimal(.01);
                pennies++;
            }

            
            Console.WriteLine("Quarters" + quarters);
            Console.WriteLine("Dimes" + dimes);
            Console.WriteLine("Nickels" + nickels);
            Console.WriteLine("Pennies" + pennies);
        }
    }

}

