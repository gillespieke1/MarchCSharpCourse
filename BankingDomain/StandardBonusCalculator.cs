namespace BankingDomain
{
    public class StandardBonusCalculator : ICalculateBonuses
    {
        public decimal GetBonusFor(IProvideBalances bankAccount, decimal amounttoDeposit)
        {
            return bankAccount.GetBalance() >= 10000 ? amounttoDeposit * 0.1M : 0;
        }
    }
}