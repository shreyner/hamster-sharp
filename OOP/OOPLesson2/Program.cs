using System;

namespace OOPLesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            var account1 = new Account();
            account1.SetAccountType(AccountType.Credit);
            account1.SetAmount(Convert.ToDecimal(23333.23));

            var account2 = new Account();
            account2.SetAccountType(AccountType.Debit);
            account2.SetAmount(Convert.ToDecimal(3333));

            Console.WriteLine("Exercise 2");
            Console.WriteLine(account1);
            Console.WriteLine(account2);
        }
    }
}
