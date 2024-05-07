using Core.Helpers.Services.ConfigurationServices.Dtos;

namespace Core.Helpers.Services.ConfigurationServices
{
    public interface IConfigurationService
    {
        ConfigurationListModelDto GetConfigurationList();
    }
}
