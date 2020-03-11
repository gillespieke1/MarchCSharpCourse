using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountTests
    {
        BankAccount account;

        public BankAccountTests()
        {
            account = new BankAccount();
        }

        [Fact]
        public void NewAccountHasCorrectBalance()
        {
            decimal currentBalance = account.GetBalance();

            Assert.Equal(7000M, currentBalance);
        }

        [Fact]
        public void WithdrawalDecreasesBalance()
        {
            // Arrange - Given
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
            var openingBalance = account.GetBalance();

            // Act - When
            try
            {
                account.Withdraw(openingBalance + 1);              
            }
            catch (Exception)
            {
                throw;
            }

            // Assert - Then
            Assert.Equal(openingBalance, account.GetBalance());
        }

        [Fact]
        public void OverdrafThrowsAnException()
        {
            Assert.Throws<OverdraftException>(() => account.Withdraw(account.GetBalance() + 1));
        }
        public decimal GetBonusFor(BankAccount bankAccount, decimal amountToDeposit)
        {
            return 0;
        }
    }
}
