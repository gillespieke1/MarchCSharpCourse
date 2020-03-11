using System;

namespace BankingDomain
{
    public class BankAccount
    {
        private decimal currentBalance = 7000;
        public decimal GetBalance()
        {
            return currentBalance;
        }

        public void Withdraw(decimal amounttoWithdraw)
        {
            if (amounttoWithdraw > currentBalance)
            {
                return;
            }
            currentBalance -= amounttoWithdraw;
        }

        public void Deposit(decimal amounttoDeposit)
        {
            currentBalance += amounttoDeposit; 
        }
    }
}