using System;

namespace BankingDomain
{
    public class BankAccount : IProvideBalances
    {
        private ICalculateBonuses BonusCalculator;
        private INotifyTheFeds FedNotifier;

        public BankAccount(ICalculateBonuses bonusCalculator, INotifyTheFeds fedNotifier)
        {
            BonusCalculator = bonusCalculator;
            FedNotifier = fedNotifier;
        }



        //public BankAccount()
        //{
        //}

        private decimal currentBalance = 7000;
        public decimal GetBalance()
        {
            return currentBalance;
        }

        public void Withdraw(decimal amounttoWithdraw)
        {
            if (amounttoWithdraw > currentBalance)
            {
                throw new OverdraftException();
            }
            else
            {
                currentBalance -= amounttoWithdraw;
                FedNotifier.NotifyOfWithdrawal(this, amounttoWithdraw);
            }
        }

        public virtual void Deposit(decimal amounttoDeposit)
        {
            // WTCYWYH
            decimal bonus = BonusCalculator.GetBonusFor(this, amounttoDeposit);
            currentBalance += amounttoDeposit + bonus; 
        }
    }
}