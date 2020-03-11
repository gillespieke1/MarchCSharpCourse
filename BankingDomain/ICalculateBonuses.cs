namespace BankingDomain
{
    public interface ICalculateBonuses
    {
        decimal GetBonusFor(IProvideBalances bankAccount, decimal amounttoDeposit);
    }
}