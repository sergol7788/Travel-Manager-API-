using Hotel.API.SecretManager;
using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.API.Extension
{
    public static class KeyVaultExtension
    {
        /// <summary>
        /// Extension method for ISecretService
        /// </summary>
        /// <returns>Returns Azure Key Vault Client</returns>
        public static KeyVaultClient GetKeyVault(this ISecretService secretService)
        {
            var keyVaultClient = new KeyVaultClient(
                async (string authority, string resource, string scope) => {

                    var context = new AuthenticationContext(authority);
                    var credential = new ClientCredential(secretService.ApplicationId, secretService.SecretKey);
                    var token = await context.AcquireTokenAsync(resource, credential);

                    return token.AccessToken;

                });

            return keyVaultClient;
        }
    }
}
