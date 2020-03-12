using BankingDomain;
using System.Windows.Forms;

namespace BankKiosk
{
    internal class WindowsFedNotifier : INotifyTheFeds
    {
        public void NotifyOfWithdrawal(BankAccount bankAccount, decimal amounttoWithdraw)
        {
            MessageBox.Show($"The fed has been notified of your activity");
        }
    }
}