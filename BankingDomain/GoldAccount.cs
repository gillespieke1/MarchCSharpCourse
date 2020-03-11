namespace BankingDomain
{
    public class GoldAccount : BankAccount
    {
        public override void Deposit(decimal amounttoDeposit)
        {
            base.Deposit(amounttoDeposit * 1.1M);
        }
    }
}