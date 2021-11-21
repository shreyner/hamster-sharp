using System;

namespace App {

    public enum AccountType
    {
        Debit,
        Credit
    }

    /// <summary>
    ///     Класс Account был взят из второго урока
    /// </summary>
    public class Account : IEquatable<Account>
    {
        private static long _lastNumber  = 0;
        public long AccountNumber {get;} = 0;
        public AccountType Type {get; set;} = AccountType.Debit;
        public decimal Amount {get; set;} = 0;

        public Account(AccountType type) {
            AccountNumber = Account.GenerateAccountNumber();
            Type = type;
        }

        public Account(decimal amount) {
            AccountNumber = Account.GenerateAccountNumber();
            Amount = amount;
        }

        public Account(AccountType type, decimal amount) {
            AccountNumber = Account.GenerateAccountNumber();
        }

        public void Transfer(Account debitAccount, decimal amount) {
            debitAccount.Amount -= amount;
            Amount += amount;
        }

        static public long GenerateAccountNumber() {
            return Account._lastNumber++;
        }

        public static bool operator ==(Account account1, Account account2)
        {
            return (bool) account1.Equals(account2);
        }
        
        public static bool operator !=(Account account1, Account account2)
        {
            return !(bool) account1.Equals(account2);
        }

        public bool Equals(Account other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            
            return AccountNumber == other.AccountNumber && Type == other.Type;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            
            return Equals((Account) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AccountNumber, (int) Type);
        }
        
        public override string ToString()
        {
            return $"AccountNumber: {AccountNumber}, AccountType: {Type}, Amount: {Amount}";
        }
    }
}
