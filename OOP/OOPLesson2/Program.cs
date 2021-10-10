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

            Console.WriteLine("Exercise 4");
            Console.WriteLine(account1);
            Console.WriteLine(account2);
        }
    }
}
