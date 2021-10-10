using System;

namespace OOPLesson2 {

    enum AccountType
    {
        Debit,
        Credit
    }

    class Account
    {
        static long LastNumber = 0;
        private long Number = 0;
        private AccountType Type = AccountType.Debit;
        private decimal Amount = 0;

        public Account() {
            Number = Account.GenerateAccountNumber();
        }

        public long GetNumber() {
            return Number;
        }

        public AccountType GetAccountType() {
            return Type;
        }

        public void SetAccountType(AccountType accountType) {
            Type = accountType;
        }

        public decimal GetAmount() {
            return Amount;
        }

        public void SetAmount(decimal amount) {
            Amount = amount;
        }

        public override string ToString()
        {
            return $"[{base.ToString()}]: Number: {Number}, AccountType: {Type}, Amount: {Amount}";
        }

        static public long GenerateAccountNumber() {
            return Account.LastNumber++;
        }
    }
}
