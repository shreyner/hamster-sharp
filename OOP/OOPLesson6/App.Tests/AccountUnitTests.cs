using System;
using Xunit;
using App;

namespace App.Tests
{
    public class AccountUnitTests
    {

        [Fact]
        public void Equals_TwoEqual_ReturnTrue()
        {
            var account1 = new Account(AccountType.Debit, 0);
            var account2 = account1;

            Assert.True(account1.Equals(account2));
        }
        
        [Fact]
        public void Equals_TwoSome_ReturnFalse()
        {
            var account1 = new Account(AccountType.Debit, 0);
            var account2 = new Account(AccountType.Debit, 0);

            Assert.False(account1.Equals(account2));
        }

        [Fact]
        public void EqualityOperator_TwoEqual_ReturnTrue()
        {
            var account1 = new Account(AccountType.Debit, 0);
            var account2 = account1;

            Assert.True(account1 == account2);
        }
        
        [Fact]
        public void EqualityOperator_TwoSome_ReturnTrue()
        {
            var account1 = new Account(AccountType.Debit, 0);
            var account2 = new Account(AccountType.Debit, 0);

            Assert.True(account1 != account2);
        }
        
        [Fact]
        public void NotEqualityOperator_TwoSome_ReturnTrue()
        {
            var account1 = new Account(AccountType.Debit, 0);
            var account2 = new Account(AccountType.Debit, 0);

            Assert.True(account1 != account2);
        }
        
        [Fact]
        public void NotEqualityOperator_TwoEqual_ReturnTrue()
        {
            var account1 = new Account(AccountType.Debit, 0);
            var account2 = account1;

            Assert.False(account1 != account2);
        }
        
        [Fact]
        public void ToString_ReturnString()
        {
            var account1 = new Account(AccountType.Debit, 0);

            Assert.Equal("AccountNumber: 0, AccountType: Debit, Amount: 0", account1.ToString());
        }
    }
}