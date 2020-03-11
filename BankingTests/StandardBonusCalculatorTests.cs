using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class StandardBonusCalculatorTests
    {
        [Fact]
        public void AccountsWithCreditBelowCutoffGetNoBonus()
        {
            // Given
            ICalculateBonuses bonusCalculator = new StandardBonusCalculator();
            //AND I have an account < 10000
            var accountsStub = new Mock<IProvideBalances>();
            accountsStub.Setup(b => b.GetBalance()).Returns(999.99M);
            // When -- When I ask it to calculate a bonus for an account < 10000 
            var bonus = bonusCalculator.GetBonusFor(accountsStub.Object, 100);

            // Then no bonus is given
            Assert.Equal(0, bonus);
        }
        [Fact]
        public void AccountsWithCreditAboveCutoffGetBonus()
        {
            // Given
            ICalculateBonuses bonusCalculator = new StandardBonusCalculator();
            // When
            var accountStub = new Mock<IProvideBalances>();
            accountStub.Setup(b => b.GetBalance()).Returns(10000);
            // When -- When I ask it to calculate a bonus for an account >= 10000 
            var bonus = bonusCalculator.GetBonusFor(accountStub.Object, 100);

            // Then a bonus is given
            Assert.Equal(10, bonus);
        }
    }
}
