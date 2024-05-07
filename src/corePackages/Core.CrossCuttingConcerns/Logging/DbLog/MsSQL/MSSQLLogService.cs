using AutoMapper;
using Azure.Security.KeyVault.Secrets;
using Core.CrossCuttingConcerns.Logging.DbLog.Dto;
using Core.CrossCuttingConcerns.Logging.DbLog.MsSQL.Contexts;
using Core.Domain.Entities;
using Core.Helpers.Services.ConfigurationServices;
using Core.Helpers.Services.ConfigurationServices.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Core.CrossCuttingConcerns.Logging.DbLog.MsSQL
{
    public class MsSqlLogService : ILogService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IConfigurationService _configurationService;

        public MsSqlLogService(IConfiguration configuration, IMapper mapper, IConfigurationService configurationService)
        {
            _configuration = configuration;
            _mapper = mapper;
            _configurationService = configurationService;
        }

        public async Task CreateLog(LogDto logDto)
        {
            Log log = _mapper.Map<Log>(logDto);
            await logToDb(log);
        }
        private async Task logToDb(Log log)
        {
            try
            {
                using var db = createDbContext();
                await db.Logs.AddAsync(log);
                await db.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException($"DB Logging Exception: {exception.Message} {Environment.NewLine} " +
                                                    $"Source: {exception.Source} {Environment.NewLine}" +
                                                    $"Stack Tree: {exception.StackTrace}");
            }
        }

        private LogDbContext createDbContext()
        {
            ConfigurationListModelDto? configurationList = _configurationService.GetConfigurationList();
            KeyVaultSecret databaseConnectionString = configurationList.SecretClient.GetSecret("MyBlogDatabaseConnectionString");
            var builder = new DbContextOptionsBuilder<LogDbContext>();
            builder.UseSqlServer(databaseConnectionString.Value);
            return new LogDbContext(builder.Options);
        }
    }
}