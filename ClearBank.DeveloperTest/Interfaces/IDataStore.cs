using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Interfaces
{
    public interface IDataStore
    {
        Account GetAccount(string accountNumber);
        void UpdateAccount(Account account);
    }
}