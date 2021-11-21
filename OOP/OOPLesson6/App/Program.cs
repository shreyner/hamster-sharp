using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var account1 = new Account(AccountType.Debit, 0);
            var account2 = new Account(AccountType.Debit, 0);

            Console.WriteLine(
                "Account1: {0}, Account2: {1}\nAccount1 == Account2: {2}",
                account1, account2,
                account1 == account2
                );
        }
    }
}