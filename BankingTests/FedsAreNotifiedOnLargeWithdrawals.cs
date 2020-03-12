using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class FedsAreNotifiedOnLargeWithdrawals
    {
        [Fact]
        public void FedNotified()
        {
            // Given -- Arrange
            var mockedFed = new Mock<INotifyTheFeds>();
            var account = new BankAccount(null, mockedFed.Object);

            // When -- Act
            account.Withdraw(5.23M);

            // Then -- Assert
            mockedFed.Verify(v => v.NotifyOfWithdrawal(account, 5.23M));
        }
    }
}
