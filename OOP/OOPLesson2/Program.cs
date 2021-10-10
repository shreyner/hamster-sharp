using System;

namespace OOPLesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            var account1 = new Account(AccountType.Credit, Convert.ToDecimal(23333.23));
            account1.SetAccountType(AccountType.Credit);
            account1.SetAmount(Convert.ToDecimal(23333.23));

            var account2 = new Account(AccountType.Debit);
            account2.SetAmount(Convert.ToDecimal(3333));

            Console.WriteLine("Exercise 3");
            Console.WriteLine(account1);
            Console.WriteLine(account2);
        }
    }
}
