using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMeet_BE.Common.Static;

namespace Azure.KeyVault
{
    public static class ConnectionHelper
    {
        public static async Task<string> GetConnectionStringAsync()
        {
            var host = await KeyVaultService.GetSecretAsync(StaticStrings.Host);
            var dbName = await KeyVaultService.GetSecretAsync(StaticStrings.DbName);
            var user = await KeyVaultService.GetSecretAsync(StaticStrings.User);
            var password = await KeyVaultService.GetSecretAsync(StaticStrings.Password);

            return $"Host={host};Database={dbName};Username={user};Password={password}";
        }
    }
}
