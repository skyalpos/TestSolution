using System;

namespace Test8_Class
{
    class TestClass
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("<name>", 1000); 
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine(account.Balance);
            Console.WriteLine(account.GetAccountHistory());

            //Test initial balance must be positive
            try
            {
                var invalid = new BankAccount("invalid", -500);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating negative intial balance account.");
                Console.WriteLine(e.ToString()); 
            }

            // Test for a negative balance. 
            try
            {
                account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw"); 
                Console.WriteLine(e.ToString());
            }

            var account1 = new BankAccount("<name>", 1000);
            Console.WriteLine($"Account {account1.Number} was created for {account1.Owner} with {account1.Balance} initial balance.");
            Console.WriteLine(account1.GetAccountHistory());


        }
    }
}
