using System;

namespace OOPLesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            var account1 = new Account(AccountType.Credit, Convert.ToDecimal(23333.23));
            account1.Type= AccountType.Credit;
            account1.Amount = Convert.ToDecimal(23333.23);

            var account2 = new Account(AccountType.Debit);
            account2.Amount = Convert.ToDecimal(3333);

            Console.WriteLine("Lessont 3 Exercise 1");
            Console.WriteLine("Before transaction");
            Console.WriteLine($"Account1: {account1}");
            Console.WriteLine($"Account2: {account2}");
            Console.WriteLine("After transaction form account1 to account2 300 amount");
            account2.Transfer(account1, 300);
            Console.WriteLine($"Account1: {account1}");
            Console.WriteLine($"Account2: {account2}");
        }
    }
}
