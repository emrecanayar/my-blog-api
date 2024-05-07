using Azure.Security.KeyVault.Secrets;

namespace Core.Helpers.Services.ConfigurationServices.Dtos
{
    public class ConfigurationListModelDto
    {
        public string TenantId { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
        public string KeyVaultUrl { get; set; } = string.Empty;
        public SecretClient? SecretClient { get; set; }
    }
}
