using System;

namespace CodeChallenge
{
    public delegate void BalanceEventHandler(decimal theValue);

    class PiggyBank
    {
        private decimal m_bankBalance;
        public event BalanceEventHandler balanceChanged;

        public decimal theBalance
        {
            set
            {
                m_bankBalance = value;
                balanceChanged(value);
            }
            get
            {
                return m_bankBalance;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PiggyBank pb = new PiggyBank();

            pb.balanceChanged += (amount) => Console.WriteLine($"The balance amount is {amount}");
            pb.balanceChanged += (amount) => { if (amount > 500.0m) Console.WriteLine($"You reached your savings goal! You have {amount}"); };
            
            string theStr;
            do
            {
                Console.WriteLine("How much to deposit?");

                theStr = Console.ReadLine();
                if(!theStr.Equals("exit"))
                {
                    if(decimal.TryParse(theStr, out decimal newVal))
                    {
                        pb.theBalance += newVal;
                    }
                    else
                    {
                        Console.WriteLine("Please enter valid number");
                    }
                }
            }
            while (!theStr.Equals("exit"));

        }
    }
}
