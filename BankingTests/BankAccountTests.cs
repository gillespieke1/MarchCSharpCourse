using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountTests
    {
        [Fact]
        public void NewAccountHasCorrectBalance()
        {
            var account = new BankAccount();

            decimal currentBalance = account.GetBalance();

            Assert.Equal(7000M, currentBalance);
        }

        [Fact]
        public void WithdrawalDecreasesBalance()
        {
            // Arrange - Given
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amounttoWithdraw = 1M;
            // Act - When
            account.Withdraw(amounttoWithdraw);
            // Assert - Then
            Assert.Equal(openingBalance - amounttoWithdraw, account.GetBalance());
        }

        [Fact]
        public void DepositIncreasesBalance()
        {
            // Arrange - Given
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amounttoDeposit = 1M;
            // Act - When
            account.Deposit(amounttoDeposit);
            // Assert - Then
            Assert.Equal(openingBalance + amounttoDeposit, account.GetBalance());
        }

        [Fact]
        public void OverdraftDoesNotDecreaseBalance()
        {
            // Arrange - Given
            var account = new BankAccount();
            var openingBalance = account.GetBalance();

            // Act - When
            account.Withdraw(openingBalance + 1);

            // Assert - Then
            Assert.Equal(openingBalance, account.GetBalance());
        }
    }
}
