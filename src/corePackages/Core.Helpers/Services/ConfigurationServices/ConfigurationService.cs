using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Core.Helpers.Services.ConfigurationServices.Dtos;
using Microsoft.Extensions.Configuration;

namespace Core.Helpers.Services.ConfigurationServices
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfiguration _configuration;

        public ConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ConfigurationListModelDto GetConfigurationList()
        {
            string? tenantId = GetConfigurationValue("TENANT_ID", "Azure:TenanId");
            string? clientId = GetConfigurationValue("CLIENT_ID", "Azure:ClientId");
            string? clientSecret = GetConfigurationValue("CLIENT_SECRET", "Azure:ClientSecret");
            string? keyVaultUrl = GetConfigurationValue("KEY_VAULT_URL", "Azure:KeyVaultUrl");

            string[] parameters = { tenantId, clientId, clientSecret, keyVaultUrl };

            if (parameters.All(string.IsNullOrEmpty))
                throw new Exception("Required Azure configuration parameters are not set.");

            SecretClient client = new SecretClient(new Uri(keyVaultUrl), new ClientSecretCredential(tenantId, clientId, clientSecret));
            return new ConfigurationListModelDto { ClientId = clientId, ClientSecret = clientSecret, KeyVaultUrl = keyVaultUrl, TenantId = tenantId, SecretClient = client };
        }

        private string? GetConfigurationValue(string envName, string configName)
        {
            return _configuration[configName] ?? Environment.GetEnvironmentVariable(envName);
        }
    }
}

