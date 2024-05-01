using System;
using System.Diagnostics;
using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using TechMeet_BE.Common.Static;

namespace Azure.KeyVault
{
    public static class KeyVaultService
    {
        private static readonly string? KeyVaultName = Environment.GetEnvironmentVariable(StaticStrings.KeyVaultName);
        private static readonly string Url = $"https://{KeyVaultName}.vault.azure.net/";

        //private static readonly string? TenantId = Environment.GetEnvironmentVariable(StaticStrings.TenantId);
        //private static readonly string? ClientId = Environment.GetEnvironmentVariable(StaticStrings.ClientId);
        //private static readonly string? ClientSecret = Environment.GetEnvironmentVariable(StaticStrings.ClientSecret);
        //private static TokenCredential _credential = new ClientSecretCredential(
        //    tenantId: TenantId, 
        //    clientId: ClientId, 
        //    clientSecret: ClientSecret);

        private static readonly TokenCredential Credential = new DefaultAzureCredential();

        private static readonly SecretClient Client = new(new Uri(Url), Credential);

        public static async Task<string> GetSecretAsync(string secretName)
        {
            var secret = await Client.GetSecretAsync(secretName);
            return secret.Value.Value;
        }

        public static async Task SetSecretAsync(string secretName, string secretValue)
        {
            await Client.SetSecretAsync(secretName, secretValue);
        }

        public static async Task DeleteSecretAsync(string secretName)
        {
            await Client.StartDeleteSecretAsync(secretName);
        }


    }
}
