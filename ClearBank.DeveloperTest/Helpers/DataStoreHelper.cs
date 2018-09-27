using System.Configuration;
using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Interfaces;

namespace ClearBank.DeveloperTest.Helpers
{
    public class DataStoreHelper : IDataStoreHelper
    {
        private readonly string _dataStoreType;

        public DataStoreHelper()
        {
            _dataStoreType = ConfigurationManager.AppSettings["DataStoreType"];
        }

        public IDataStore GetDataStoreType()
        {
            if (_dataStoreType == "Backup")
            {
                return new BackupAccountDataStore();
            }
            return new AccountDataStore();
        }
    }
}