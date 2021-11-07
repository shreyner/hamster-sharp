using System;

namespace OOPLesson2 {

    enum AccountType
    {
        Debit,
        Credit
    }

    class Account
    {
        static long LastNumber  = 0;
        public long Number {get;} = 0;
        public AccountType Type {get; set;} = AccountType.Debit;
        public decimal Amount {get; set;} = 0;

        public Account() {
            Number = Account.GenerateAccountNumber();
        }

        public Account(AccountType type) {
            Number = Account.GenerateAccountNumber();
            Type = type;
        }

        public Account(decimal amount) {
            Number = Account.GenerateAccountNumber();
            Amount = amount;
        }

        public Account(AccountType type, decimal amount) {
            Number = Account.GenerateAccountNumber();
        }

        public void Transfer(Account debitAccount, decimal amount) {
            debitAccount.Amount -= amount;
            Amount += amount;
        }

        public override string ToString()
        {
            return $"Number: {Number}, AccountType: {Type}, Amount: {Amount}";
        }

        static public long GenerateAccountNumber() {
            return Account.LastNumber++;
        }
    }
}
