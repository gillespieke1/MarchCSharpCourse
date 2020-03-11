using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class GoldAccountTests
    {
        [Fact]
        public void TheBonusCalculatorIsUsedToCalculateBonuses()
        {
            var stubbedBonusCalculator = new Mock<ICalculateBonuses>();

            var account = new BankAccount(stubbedBonusCalculator.Object);
            stubbedBonusCalculator.Setup(b => b.GetBonusFor(account, 100)).Returns(42);
            var openingBalance = account.GetBalance();

            account.Deposit(100);

            Assert.Equal(142 + openingBalance, account.GetBalance());
        }
    }
}
