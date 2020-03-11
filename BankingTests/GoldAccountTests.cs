using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class GoldAccountTests
    {
        [Theory]
        [InlineData(100, 10)]
        [InlineData(1000, 100)]
        public void DepositsGetTheBonus(decimal amount, decimal bonus)
        {
            var account = new GoldAccount();
            var initialBalance = account.GetBalance();

            account.Deposit(amount);

            Assert.Equal(
                initialBalance + amount + bonus,
                account.GetBalance());
        }
    }
}
