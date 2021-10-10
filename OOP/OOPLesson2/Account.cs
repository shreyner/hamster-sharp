using System;

namespace OOPLesson2 {

    enum AccountType
    {
        Debit,
        Credit
    }

    class Account
    {
        private long Number = 0;
        private AccountType Type = AccountType.Debit;
        private decimal Amount = 0;

        public long GetNumber() {
            return Number;
        }

        public void SetNumber(long number) {
            Number = number;
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
    }
}
